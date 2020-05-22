using System.Collections.Generic;

namespace TvShows.ViewModels
{
    public class Show
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<Person> Cast { get; set; }
    }
}
