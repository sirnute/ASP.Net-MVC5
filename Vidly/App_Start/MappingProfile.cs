using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {

            //Domain to Dto
            Mapper.CreateMap<Customer, CustomerDto>();

            //Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c => c.Id, opt => opt.Ignore());

            //Domain to Dto
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();


            //Domain to Dto
            Mapper.CreateMap<Movie, MovieDto>();

            //Dto to Domain
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.ID, opt => opt.Ignore());
            //Domain to Dto
            Mapper.CreateMap<GenreType, GenreTypeDto>();
        }
    }
}