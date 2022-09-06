using AutoMapper;
using HumansVsZombies_Backend.DTOs.ChatDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class ChatProfile : Profile
    {
        public ChatProfile()
        {
            //Chat<->ChatReadDTO
            CreateMap<Chat, ChatReadDTO>()
               .ForMember(cdto => cdto.Player, opt => opt
               .MapFrom(c => c.PlayerId))
               .ForMember(cdto => cdto.Game, opt => opt
               .MapFrom(c => c.GameId))
               .ForMember(cdto => cdto.Squad, opt => opt
               .MapFrom(c => c.SquadId))
               .ReverseMap();

            //Chat<->ChatCreateDTO
            CreateMap<Chat, ChatCreateDTO>().ReverseMap();

            //Chat<->ChatUpdateDTO
            CreateMap<Chat, ChatUpdateDTO>()
                .ForMember(cdto => cdto.GameId, opt => opt
                .MapFrom(c => c.GameId))
                .ForMember(cdto => cdto.PlayerId, opt => opt
                .MapFrom(c => c.PlayerId))
                .ForMember(cdto => cdto.SquadId, opt => opt
                .MapFrom(c => c.SquadId))
                .ReverseMap();
        }
       
    }
}
