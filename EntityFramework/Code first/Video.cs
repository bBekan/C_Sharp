using System;
using System.Collections.Generic;

namespace codeFirst
{
    public class Video
    {
        public int id { get; set; }
        public string name { get; set; }
        public DateTime releaseDate { get; set; }
        public virtual Genre genre { get; set; }
        public int genreId { get; set; }
        public Classification classification { get; set; }
        public ICollection<Tag> tags { get; set; }
        public Video()
        {
            tags = new HashSet<Tag>();
        }
    }
}