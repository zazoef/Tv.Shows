using AutoMapper;

using System.Collections.Generic;
using System.Linq;

using TvShows.Interfaces.Repository;
using TvShows.Interfaces.Services;
using TvShows.Models;
using TvShows.ViewModels;

namespace TvShows.Services
{
    public class ShowService : IShowService
    {
        private readonly IMapper _mapper;
        private readonly IFileRepository<Show> _fileRepository;
        public ShowService(IFileRepository<Show> fileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _fileRepository = fileRepository;
        }
        public List<ShowViewModel> GetByPage(int page, int pageSize = 10)
        {
            var shows = _fileRepository.Read();
            if (shows == null)
            {
                return null;
            }
            var list =  shows.Take(pageSize).Skip((page - 1) * pageSize).ToList();
            return _mapper.Map<List<ShowViewModel>>(list);
        }
    }
}
