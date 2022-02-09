

using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new VidzyContext();
            var sortedActionMovies = db.Videos.Where(v => v.Genre.Name == "Action")
                .OrderBy(v => v.Name);
            System.Console.WriteLine("Sorted action movies: ");
            foreach (var movie in sortedActionMovies)
            {
                System.Console.WriteLine("Title: " + movie.Name);
            }

            var goldDramaByReleaseDate = db.Videos.Where(v => v.Genre.Name == "Drama" && v.Classification == Classification.Gold)
                .OrderByDescending(v => v.ReleaseDate);
            System.Console.WriteLine("\nSorted gold drama movies: ");
            foreach (var movie in goldDramaByReleaseDate)
            {
                System.Console.WriteLine("Title: " + movie.Name);
            }

            var projectedMovies = db.Videos.Select(v => new { movieName = v.Name, movieGenre = v.Genre.Name });
            System.Console.WriteLine("\nProjected movies with genres");
            foreach (var movie in projectedMovies)
            {
                System.Console.WriteLine("Title: {0}, Genre: {1}", movie.movieName, movie.movieGenre);
            }

            var moviesByClassification = db.Videos.GroupBy(v => v.Classification)
                .Select(g => new
                {
                    classification = g.Key.ToString(),
                    movies = g.OrderBy(v => v.Name)
                });

            foreach (var classification in moviesByClassification)
            {
                System.Console.WriteLine("\nClassification: " + classification.classification);
                foreach (var movie in classification.movies)
                {
                    System.Console.WriteLine("\t{0}", movie.Name);
                }
            }

            var movieCountByClassification = db.Videos.GroupBy(v => v.Classification)
                 .Select(g => new
                 {
                     classification = g.Key.ToString(),
                     movieCount = g.Count()
                 })
                 .OrderBy(c => c.classification);
            System.Console.WriteLine();
            foreach (var group in movieCountByClassification)
            {
                System.Console.WriteLine("{0}: ({1})", group.classification, group.movieCount);
            }

            var sortedByGenresAndNumOfVideos = db.Genres.GroupJoin(db.Videos,
                 g => g.Id,
                 v => v.GenreId,
                 (genres, movies) => new
                 {
                     movieCount = movies.Count(),
                     genre = genres.Name
                 })
                .OrderByDescending(c => c.movieCount).ThenBy(c => c.genre);

            System.Console.WriteLine();
            foreach(var group in sortedByGenresAndNumOfVideos)
            {
                System.Console.WriteLine("{0}: ({1})", group.genre, group.movieCount);
            }
        }

    }
}
