using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Vidly.Models;

namespace Vidly.Areas.Identity.Data;

// Add profile data for application users by adding properties to the VidlyUser class
public class VidlyUser : IdentityUser
{
    [Required]
    public string DrivingLicense { get; set; }

}

