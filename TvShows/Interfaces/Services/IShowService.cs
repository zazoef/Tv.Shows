using System.Collections.Generic;

using TvShows.Models;

namespace TvShows.Interfaces.Services
{
    public interface IShowService
    {
        List<TvShows.ViewModels.ShowViewModel> GetByPage(int page, int pageSize = 10);
    }
}
