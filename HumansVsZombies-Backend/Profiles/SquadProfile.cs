using AutoMapper;
using HumansVsZombies_Backend.DTOs.SquadDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class SquadProfile : Profile
    {
        public SquadProfile()
        {
            //Squad<->SquadReadDTO
            CreateMap<Squad, SquadReadDTO>()
            .ForMember(g => g.Game, opt => opt
               .MapFrom(g => g.GameId))
                // Turning related chats into int Arrays
               .ForMember(c => c.Chats, opt => opt
               .MapFrom(c => c.Chats.Select(x => x.ChatId).ToArray()))
               // Turning related squadcheckins into int Arrays
               .ForMember(s => s.SquadCheckins, opt => opt
               .MapFrom(s => s.SquadCheckins.Select(x => x.SquadCheckinId).ToArray()))
               // Turning related squadmembers into int Arrays
               .ForMember(s => s.SquadMembers, opt => opt
               .MapFrom(s => s.SquadMembers.Select(x => x.SquadMemberId).ToArray()))
               .ReverseMap();

            //Squad<->SquadCreateDTO
            CreateMap<Squad, SquadCreateDTO>().ReverseMap();


            //Squad<->SquadUpdateDTO
            CreateMap<Squad, SquadUpdateDTO>()
                .ForMember(g => g.GameId, opt => opt
                .MapFrom(g => g.GameId))
                .ReverseMap();
        }
    }
}
