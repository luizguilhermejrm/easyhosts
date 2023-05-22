﻿using AutoMapper;
using Easy.Hosts.Core.Domain;
using Easy.Hosts.Core.DTOs.Booking;

namespace Easy.Hosts.Core.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<BookingCreateDto, Booking>().ReverseMap();
            CreateMap<Booking, BookingReadDto>().ReverseMap();
        }
    }
}