using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvShows.Models
{
    public class Cast
    {
        public Person person { get; set; }
        public Character character { get; set; }
        public bool self { get; set; }
        public bool voice { get; set; }
    }

}
