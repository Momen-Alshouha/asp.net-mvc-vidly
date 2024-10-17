using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using asp.net_vidly.Dtos;
using asp.net_vidly.Models;
using AutoMapper;

namespace asp.net_vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto,Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
        }
    }
}