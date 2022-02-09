using System.Data.Entity;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            //Lazy loading
            var db = new VidzyContext();
            var videos = db.Videos.ToList();

            foreach(var video in videos)
            {
                System.Console.WriteLine("{0}, {1}", video.Name, video.Genre.Name);
            }

            //Eager loading
            var videos2 = db.Videos.Include(v => v.Genre).ToList();

            System.Console.WriteLine();
            foreach (var video in videos2)
            {
                System.Console.WriteLine("{0}, {1}", video.Name, video.Genre.Name);
            }

            //Explicit loading
            var genreIds = db.Genres.Select(g => g.Id);
            var videos3 = db.Videos.Where(v => genreIds.Contains(v.GenreId));

            System.Console.WriteLine();
            foreach (var video in videos3)
            {
                System.Console.WriteLine("{0}, {1}", video.Name, video.Genre.Name);
            }
        }
    }
}
