using AutoMapper;
using HumansVsZombies_Backend.DTOs.PlayerDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class PlayerProfile: Profile
    {
        public PlayerProfile()
        {
            //Player<->PlayerReadDTO
            CreateMap<Player, PlayerReadDTO>()
            .ForMember(p => p.Game, opt => opt
               .MapFrom(p => p.GameId))
               .ForMember(u => u.User, opt => opt
               .MapFrom(u => u.UserId))
               // Turning related chats into int Arrays
               .ForMember(c => c.Chats, opt => opt
               .MapFrom(c => c.Chats.Select(x => x.ChatId).ToArray()))
               .ReverseMap();

            //Player<->PlayerCreateDTO
            CreateMap<Player, PlayerCreateDTO>().ReverseMap();


            //Player<->PlayerUpdateDTO
            CreateMap<Player, PlayerUpdateDTO>().ReverseMap();
        }
    }
}
