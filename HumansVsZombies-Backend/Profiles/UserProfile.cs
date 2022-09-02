using AutoMapper;
using HumansVsZombies_Backend.DTOs.UserDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            //User<->UserReadDTO
            CreateMap<User, UserReadDTO>()
                // Turning related players into int Arrays
                .ForMember(u => u.Players, opt => opt
                .MapFrom(u => u.Players.Select(x => x.PlayerId).ToArray()))
                .ReverseMap();

            //User<->UserCreateDTO
            CreateMap<User, UserCreateDTO>().ReverseMap();


            //User<->UserUpdateDTO
            CreateMap<User, UserUpdateDTO>().ReverseMap();

        }

    }
}
