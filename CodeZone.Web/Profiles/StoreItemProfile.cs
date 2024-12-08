using AutoMapper;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;

namespace CodeZone.Web.Profiles
{
    public class StoreItemProfile : Profile
    {
        public StoreItemProfile()
        {
            CreateMap<StoreItem, StoreItemViewModel>().ReverseMap();
        }
    }
}
