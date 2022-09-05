using AutoMapper;
using HumansVsZombies_Backend.DTOs.MissionDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class MissionProfile : Profile
    {
        public MissionProfile()
        {
            //Mission<->MissionReadDTO
            CreateMap<Mission, MissionReadDTO>()
               .ForMember(m => m.Game, opt => opt
               .MapFrom(x => x.GameId))
               .ReverseMap();

            //Mission<->MissionCreateDTO
            CreateMap<Mission, MissionCreateDTO>().ReverseMap();


            //Mission<->MissionUpdateDTO
            CreateMap<Mission, MissionUpdateDTO>()
                .ForMember(m => m.GameId, opt => opt
                .MapFrom(x => x.GameId))
                .ReverseMap(); ;
        }
    }
}
