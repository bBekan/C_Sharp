using ImenikAPI.Areas.Identity.Data;
using ImenikAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ImenikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            _configuration = configuration;

            AddAdmin();
        }
        /// <summary>
        /// Login
        /// </summary>
        /// <param name="loginUser"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginModel loginUser)
        {
            var user = await userManager.FindByNameAsync(loginUser.Username);
            if (user != null && await userManager.CheckPasswordAsync(user, loginUser.Password))
            {

                var userRoles = await userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

                var token = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(30),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();

        }
        /// <summary>
        /// Register user
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        [HttpPost("register/user")]
        public async Task<IActionResult> Register(RegisterModel registerUser)
        {
            var userExists = await userManager.FindByNameAsync(registerUser.Username);
            if (userExists != null)
                return Problem("User already exists");

            AppUser user = new AppUser()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };
            var result = await userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
                return Problem(result.Errors.First().Description);

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole(Roles.User));

                await userManager.AddToRoleAsync(user, Roles.User);

            return Ok("User created successfully!");
        }
        /// <summary>
        /// Register admin
        /// </summary>
        /// <param name="registerUser"></param>
        /// <returns></returns>
        [HttpPost("register/admin")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RegisterAdmin(RegisterModel registerUser)
        {
            var userExists = await userManager.FindByNameAsync(registerUser.Username);
            if (userExists != null)
                return Problem("User already exists");

            AppUser user = new AppUser()
            {
                Email = registerUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = registerUser.Username
            };
            var result = await userManager.CreateAsync(user, registerUser.Password);

            if (!result.Succeeded)
                return Problem(result.Errors.First().Description);

            if (!await roleManager.RoleExistsAsync(Roles.Admin))
                await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
            if (!await roleManager.RoleExistsAsync(Roles.User))
                await roleManager.CreateAsync(new IdentityRole(Roles.User));

            await userManager.AddToRoleAsync(user, Roles.Admin);
            await userManager.AddToRoleAsync(user, Roles.User);

            return Ok("User created successfully!");
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        public async void AddAdmin()
        {
            if (await userManager.FindByNameAsync("admin") == null)
            {
                AppUser user = new AppUser()
                {
                    Email = "admin@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "admin"
                };
                var result = await userManager.CreateAsync(user, "@dMIN123");


                if (!await roleManager.RoleExistsAsync(Roles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(Roles.Admin));
                if (!await roleManager.RoleExistsAsync(Roles.User))
                    await roleManager.CreateAsync(new IdentityRole(Roles.User));

                await userManager.AddToRoleAsync(user, Roles.User);
                await userManager.AddToRoleAsync(user, Roles.Admin);


            }
        }
    }
}
