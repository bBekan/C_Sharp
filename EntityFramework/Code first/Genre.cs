using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeFirst
{
    public class Genre
    {
        public int id { get; set; }
        public string name { get; set; }
        public virtual List<Video> videos { get; set; } = new List<Video>();
    }
}
