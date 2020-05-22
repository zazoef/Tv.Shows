using System;
using System.Collections.Generic;
using System.Linq;
using TvShows.Interfaces.Repository;
using TvShows.Interfaces.Services;
using TvShows.Models;

namespace TvShows.Services
{
    public class ShowService : IShowService
    {
        private readonly IFileRepository<Show> _fileRepository;
        public ShowService(IFileRepository<Show> fileRepository)
        {
            _fileRepository = fileRepository;
        }
        public List<Show> GetByPage(int page, int pageSize = 10)
        {
            var shows = _fileRepository.Read();
            if (shows == null)
            {
                return null;
            }
            return shows.Take(pageSize).Skip((page - 1) * pageSize).ToList();
        }
    }
}
