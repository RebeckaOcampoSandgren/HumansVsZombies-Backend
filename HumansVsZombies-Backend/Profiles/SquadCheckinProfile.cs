using AutoMapper;
using HumansVsZombies_Backend.DTOs.SquadCheckinDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class SquadCheckinProfile: Profile
    {
        public SquadCheckinProfile()
        {
            // SquadCheckin<->SquadCheckinReadDTO
            CreateMap<SquadCheckin, SquadCheckinReadDTO>()
            .ForMember(p => p.Game, opt => opt
               .MapFrom(p => p.GameId))
               .ForMember(s => s.Squad, opt => opt
               .MapFrom(s => s.SquadId))
               .ForMember(s => s.SquadMember, opt => opt
               .MapFrom(s => s.SquadMemberId))
               .ReverseMap();

            //SquadCheckin<->SquadCheckinCreateDTO
            CreateMap<SquadCheckin, SquadCheckinCreateDTO>().ReverseMap();


            //SquadCheckin<->SquadCheckinUpdateDTO
            CreateMap<SquadCheckin, SquadCheckinUpdateDTO>()
               .ForMember(g => g.GameId, opt => opt
               .MapFrom(g => g.GameId))
               .ForMember(s => s.SquadId, opt => opt
               .MapFrom(s => s.SquadId))
               .ForMember(s => s.SquadMemberId, opt => opt
               .MapFrom(s => s.SquadMemberId))  
               .ReverseMap();
        }
    }
}
