using AutoMapper;
using HumansVsZombies_Backend.DTOs.GameDTO;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Profiles
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            //Game<->GameReadDTO
            CreateMap<Game, GameReadDTO>()
                // Turning related chats into int Arrays
                .ForMember(g => g.Chats, opt => opt
                .MapFrom(g => g.Chats.Select(x => x.ChatId).ToArray()))
                // Turning related squads into int Arrays
                .ForMember(g => g.Squads, opt => opt
                .MapFrom(g => g.Squads.Select(x => x.SquadId).ToArray()))
                // Turning related missions into int Arrays
                .ForMember(g => g.Missions, opt => opt
                .MapFrom(g => g.Missions.Select(x => x.MissionId).ToArray()))
                // Turning related players into int Arrays
                .ForMember(g => g.Players, opt => opt
                .MapFrom(g => g.Players.Select(x => x.PlayerId).ToArray()))
                .ReverseMap();

            //Game<->GameCreateDTO
            CreateMap<Game, GameCreateDTO>().ReverseMap();

            //Game<->GameUpdateDTO
            CreateMap<Game, GameUpdateDTO>().ReverseMap();
        }
    }
}
