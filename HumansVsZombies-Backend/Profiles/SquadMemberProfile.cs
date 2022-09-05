using AutoMapper;
using HumansVsZombies_Backend.DTOs.SquadMemberDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class SquadMemberProfile: Profile
    {
        public SquadMemberProfile()
        {
            //  SquadMember<->SquadMemberReadDTO
            CreateMap<SquadMember, SquadMemberReadDTO>()
            .ForMember(s => s.Squad, opt => opt
               .MapFrom(p => p.SquadId))
               .ForMember(p => p.Player, opt => opt
               .MapFrom(s => s.PlayerId))
               // Turning related Squadcheckins into int Arrays
               .ForMember(s => s.SquadCheckins, opt => opt
               .MapFrom(s => s.SquadCheckins.Select(x => x.SquadCheckinId).ToArray()))
               .ReverseMap();

            //SquadMember<->SquadMemberCreateDTO
            CreateMap<SquadMember, SquadMemberCreateDTO>().ReverseMap();


            //SquadMember<->SquadMemberUpdateDTO
            CreateMap<SquadMember, SquadMemberUpdateDTO>()
               .ForMember(s => s.SquadId, opt => opt
               .MapFrom(s => s.SquadId))
               .ForMember(p => p.PlayerId, opt => opt
               .MapFrom(p => p.PlayerId))
               .ReverseMap();
        }
    }
}
