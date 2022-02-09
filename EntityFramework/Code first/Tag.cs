using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeFirst
{
    public class Tag
    {
        public int tagId { get; set; }
        public string name { get; set; }
        public ICollection<Video> videos { get; set; } 
        public Tag()
        {
            videos =  new HashSet<Video>();
        }
    }
}
