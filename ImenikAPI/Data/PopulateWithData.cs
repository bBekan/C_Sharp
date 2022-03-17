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

        public void PopulateData()
        {
            var Croatia = new Country()
            {
                Id = 1,
                Name = "Croatia",
                Abbreviation = "CRO",
                IsInEu = "EU"
            };
            _context.Add(Croatia);

            var UnitedKingdom= new Country()
            {
                Id = 2,
                Name = "United Kingdom",
                Abbreviation = "UK",
                IsInEu = "Other countries"
            };
            _context.Add(UnitedKingdom);

            var USA = new Country()
            {
                Id = 3,
                Name = "United States of America",
                Abbreviation = "USA",
                IsInEu = "Other countries"
            };
            _context.Add(USA);

            var Spain = new Country()
            {
                Id = 4,
                Name = "Spain",
                Abbreviation = "ES",
                IsInEu = "EU"
            };
            _context.Add(Spain);

            var GradZagreb = new County()
            {
                Id = 1,
                Name = "Grad Zagreb",
                Abbreviation = "GZ",
                CountryId = Croatia.Id,
                Country = Croatia,
                AreaCode = "10000",

            };
            _context.Add(GradZagreb);

            var SibenskoKninska = new County()
            {
                Id = 2,
                Name = "Šibensko-Kninska",
                Abbreviation = "ŠK",
                CountryId = Croatia.Id,
                Country = Croatia,
                AreaCode = "22000",
            };
            _context.Add(SibenskoKninska);

            var Bristol = new County()
            {
                Id = 3,
                Name = "Bristol",
                Abbreviation = "BRI",
                CountryId = UnitedKingdom.Id,
                Country = UnitedKingdom,
                AreaCode = "0117",
            };
            _context.Add(Bristol);

            var LosAngeles = new County()
            {
                Id = 4,
                Name = "Los Angeles County",
                Abbreviation = "LAC",
                CountryId = USA.Id,
                Country = USA,
                AreaCode = "213",
            };
            _context.Add(LosAngeles);

            var Andalusia = new County()
            {
                Id = 5,
                Name = "Andalusia",
                Abbreviation = "AND",
                CountryId = Spain.Id,
                Country = Spain,
                AreaCode = "334"
            };
            _context.Add(Andalusia);
            _context.SaveChanges();
        }
    }
}
