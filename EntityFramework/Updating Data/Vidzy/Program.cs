
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vidzy
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new VidzyContext())
            {
                //Adding movie
                var actionId = db.Genres.SingleOrDefault(g => g.Name == "Action").Id;
                db.Videos.Add(new Video
                {
                    Name = "Terminator 1",
                    GenreId = actionId,
                    ReleaseDate = new DateTime(1984, 10, 26)
                });
                db.SaveChanges();

                //Adding tags
                addTags(new Tag { Name = "classics" }, new Tag { Name = "drama" });

                //Adding tags to video with id 1
                var tags = new Tag[3];
                tags[0] = (new Tag { Name = "classics" });
                tags[1] = (new Tag { Name = "drama" });
                tags[2] = (new Tag { Name = "comedy" });
                addTagsToVideoWithId(1, tags);

                //Removing tags from videos
                removeTagsFromVideo(1, tags[0]);

                //Removing genre by id
                removeGenreById(2);
            }
        }

        private static void removeGenreById(int genreId)
        {
            using (var db = new VidzyContext())
            {
                var genre = db.Genres.SingleOrDefault(g => g.Id == genreId);
                if(genre != null)
                {
                    var videos = db.Videos.Where(v => v.Genre.Name == genre.Name);
                    foreach (var vid in videos) Console.WriteLine(vid.Name);
                    db.Videos.RemoveRange(videos);
                    db.Genres.Remove(genre);
                    db.SaveChanges();
                }
            }
        }

        private static void removeTagsFromVideo(int videoId, params Tag[] tags)
        {
            using(var db = new VidzyContext())
            {
                var video = db.Videos.SingleOrDefault(v => v.Id == videoId);
                if(video != null)
                {
                    foreach(var tag in tags)
                    {
                        video.RemoveTag(tag.Name);
                    }
                }
                db.SaveChanges();
            }
        }

        public static void addTags(params Tag[] tags)
        {
            using (var db = new VidzyContext())
            {
                var tagList = db.Tags.Select(t => t.Name);
                foreach (var tag in tags)
                {
                    if (!tagList.Contains(tag.Name))
                    {
                        db.Tags.Add(tag);
                        db.SaveChanges();
                    }
                }

            }

        }
        private static void addTagsToVideoWithId(int videoId, params Tag[] tags)
        {
            using (var db = new VidzyContext())
            {
                var video = db.Videos.SingleOrDefault(v => v.Id == videoId);
                var tagList = db.Tags.Select(t => t.Name);
                foreach (var tag in tags)
                {
                    if (tagList.Contains(tag.Name))
                    {
                        var existingTag = db.Tags.SingleOrDefault(t => t.Name == tag.Name);
                        video.AddTag(existingTag);
                    }
                    else
                    {
                        video.AddTag(tag);
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
