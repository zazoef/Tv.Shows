using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TvShows.Interfaces.Services;
using TvShows.ViewModels;

namespace TvShows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowsController : ControllerBase
    {
        private readonly IShowService _showService;
        public ShowsController(IShowService showService)
        {
            _showService = showService;
        }
        [HttpGet("{id}", Name = "Get")]
        public List<ShowViewModel> Get(int id)
        {
            return _showService.GetByPage(id);
        }
    }
}