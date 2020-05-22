using System.Collections.Generic;
using System.Net.Http;

using TvShows.Interfaces.Repository;
using TvShows.Interfaces.Services;
using TvShows.Models;
using TvShows.Wrapper;

namespace TvShows.Services
{
    public class ScraperService: IScraperService
    {
        private readonly HttpClient _httpClient;
        private readonly IFileRepository<Show> _fileRepository;
        public ScraperService(HttpClient httpClient, IFileRepository<Show> fileRepository)
        {
            _httpClient = httpClient;
            _fileRepository = fileRepository;
        }
        public List<Show> GetShows()
        {
            var shows = Read();
            if (shows != null)
            {
                return shows;
            }

            shows = GetFromApi();
            AddCast(shows);
            if (shows != null)
            {
                _fileRepository.Write(shows);
            }

            return shows;
        }

        private List<Show> Read()
        {
            return _fileRepository.Read();
        }

        private List<Show> GetFromApi()
        {
            List<Show> shows;
            var wrapper = new HttpClientWrapper();
            var task = wrapper.GetWithPolly<List<Show>>(_httpClient, $"shows");
            shows = task.Result;
            return shows;
        }

        private void AddCast(List<Show> shows)
        {
            foreach (var show in shows)
            {
                show.Cast = GetCast(show.Id);
            }
        }

        private IList<Cast> GetCast(long id)
        {
            var wrapper = new HttpClientWrapper();
            var task = wrapper.GetWithPolly<IList<Cast>>(_httpClient,$"shows/{id}/cast"); 
            return task.Result;
        }
    }
}
