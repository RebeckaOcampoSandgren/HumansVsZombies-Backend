using AutoMapper;
using HumansVsZombies_Backend.DTOs.KillDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class KillProfile : Profile
    {
        public KillProfile()
        {
            // Kill<->KillReadDTO
            CreateMap<Kill, KillReadDTO>()
                .ForMember(g => g.Game, opt => opt
               .MapFrom(g => g.GameId))
               .ForMember(k => k.Killer, opt => opt
               .MapFrom(k => k.KillerId))
               .ForMember(v => v.Victim, opt => opt
               .MapFrom(v => v.VictimId))
               .ReverseMap();

            // Kill<->KillCreateDTO
            CreateMap<Kill, KillCreateDTO>().ReverseMap();

            // Kill<->KillUpdateDTO
            CreateMap<Kill, KillUpdateDTO>()
               .ForMember(g => g.GameId, opt => opt
               .MapFrom(g => g.GameId))
               .ForMember(k => k.KillerId, opt => opt
               .MapFrom(k => k.KillerId))
               .ForMember(v => v.VictimId, opt => opt
               .MapFrom(v => v.VictimId))
               .ReverseMap();
        }
    }
}
