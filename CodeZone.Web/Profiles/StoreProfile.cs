﻿using AutoMapper;
using CodeZone.DataAccess.Models;
using CodeZone.Web.ViewModels;

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
