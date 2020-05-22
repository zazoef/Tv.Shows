using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TvShows.Models
{
    public class Show
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<Cast> Cast { get; set; }
    }
}
