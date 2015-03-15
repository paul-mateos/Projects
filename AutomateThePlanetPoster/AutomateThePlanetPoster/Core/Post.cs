using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateThePlanetPoster.Core
{
    public class Post
    {
        public string Url { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Site { get; set; }
        public PostTypes PostType { get; set; }
        public bool IsTrackBack { get; set; }
    }
}
