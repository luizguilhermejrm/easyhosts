﻿using AutoMapper;
using Easy.Hosts.Core.DTOs.BedroomDto;
using Easy.Hosts.Core.Domain;

namespace Easy.Hosts.Core.Profiles
{
    public class BedroomProfiles : Profile
    {
        public BedroomProfiles()
        {
            CreateMap<Bedroom, BedroomReadDto>().ReverseMap();
            CreateMap<Bedroom, BedroomCreateDto>().ReverseMap();
        }
    }
}
