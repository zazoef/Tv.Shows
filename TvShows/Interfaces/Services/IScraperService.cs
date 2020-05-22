using System.Collections.Generic;
using TvShows.Models;

namespace TvShows.Interfaces.Services
{
    public interface IScraperService
    {
        List<Show> GetShows();       
    }
}
