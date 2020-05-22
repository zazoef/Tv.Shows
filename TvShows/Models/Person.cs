using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvShows.Models
{
    public class Person
    {
        public long Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
        public object Deathday { get; set; }
        public string Gender { get; set; }
    }
}
