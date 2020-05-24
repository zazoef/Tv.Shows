using System.Collections.Generic;

namespace TvShows.ViewModels
{
    public class ShowViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IList<PersonViewModel> Cast { get; set; }
    }
}
