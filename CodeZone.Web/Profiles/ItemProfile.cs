using AutoMapper;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;

namespace CodeZone.Web.Profiles
{
    public class ItemProfile : Profile
    {
        public ItemProfile()
        {
            CreateMap<Item,ItemViewModel>().ReverseMap();
        }
    }
}
