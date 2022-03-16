using ImenikAPI.Models;

namespace ImenikAPI.Scripts
{
    public class PopulateWithData
    {
        public InMemoryDbContext _context { get; set; }
        public PopulateWithData(InMemoryDbContext context)
        {
            _context = context;
        }

        public void PopulateCountries()
        {
            List<Country> countries = new List<Country>();
            countries.Add(new Country()
            {
                Id = 1,
                Name = "Croatia",
                Abbreviation = "CRO",
                IsInEu = "EU"
            });

            countries.Add(new Country()
            {
                Id = 2,
                Name = "United Kingdom",
                Abbreviation = "UK",
                IsInEu = "Other countries"
            });

            countries.Add(new Country()
            {
                Id = 3,
                Name = "United States of America",
                Abbreviation = "USA",
                IsInEu = "Other countries"
            });

            countries.Add(new Country()
            {
                Id = 4,
                Name = "Spain",
                Abbreviation = "ES",
                IsInEu = "EU"
            });

            _context.Countries.AddRange(countries);
            _context.SaveChanges();
        }

        public void PopulateCounties()
        {
            List<County> counties = new List<County>();
            counties.Add(new County()
            {
                Id = 1,
                Name = "Grad Zagreb",
                Abbreviation = "GZ",
                CountryId = 1,
                Country = _context.Countries.Single(c => c.Id == 1),
                AreaCode = "10000",

            }) ;

            counties.Add(new County()
            {
                Id = 2,
                Name = "Šibensko-Kninska",
                Abbreviation = "ŠK",
                CountryId = 1,
                Country = _context.Countries.Single(c => c.Id == 1),
                AreaCode = "22000",

            });
            counties.Add(new County()
            {
                Id = 3,
                Name = "Bristol",
                Abbreviation = "BRI",
                CountryId = 2,
                Country = _context.Countries.Single(c => c.Id == 2),
                AreaCode = "0117",
            });

            counties.Add(new County()
            {
                Id = 4,
                Name = "Los Angeles County",
                Abbreviation = "LAC",
                CountryId = 3,
                Country = _context.Countries.Single(c => c.Id == 3),
                AreaCode = "213",
            });

            counties.Add(new County()
            {
                Id = 5,
                Name = "Andalusia",
                Abbreviation = "AND",
                CountryId = 4,
                Country = _context.Countries.Single(c => c.Id == 4),
                AreaCode = "334"
            });

            _context.Counties.AddRange(counties);
            _context.SaveChanges();
        }
    }
}
