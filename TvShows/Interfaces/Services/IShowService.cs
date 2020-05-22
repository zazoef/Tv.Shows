using System.Collections.Generic;

using TvShows.Models;

namespace TvShows.Interfaces.Services
{
    public interface IShowService
    {
        List<Show> GetByPage(int page, int pageSize = 10);
    }
}
