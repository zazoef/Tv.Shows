using AutoMapper;
using System.Linq;
using TvShows.Models;
using TvShows.ViewModels;

namespace TvShows.Profiles
{
    public class ShowProfile : Profile
    {
        public ShowProfile()
        {
            CreateMap<Show, ShowViewModel>()
                .ForMember(
                    d => d.Cast, 
                    s => s.MapFrom(
                        m => m.Cast.Select(x => x.Person).OrderBy(y => y.Birthday)));                
            CreateMap<Person, PersonViewModel>(); 
        }
    }
}
