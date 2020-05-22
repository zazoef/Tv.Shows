using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using TvShows.Interfaces.Services;
using TvShows.Models;

namespace TvShows.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScraperController : ControllerBase
    {
        private readonly IScraperService _scraperService;
        public ScraperController(IScraperService scraperService)
        {
            _scraperService = scraperService;
        }
        [HttpGet]
        public List<Show> Get()
        {
            var shows = _scraperService.GetShows();
            return shows;
        }           
    }
}