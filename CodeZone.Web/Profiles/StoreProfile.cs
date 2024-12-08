using AutoMapper;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodeZone.Web.Profiles
{
    public class StoreProfile : Profile
    {
        public StoreProfile()
        {
            CreateMap<Store, StoreViewModel>().ReverseMap();
        }
    }
}
