using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Data
{
    public class SeedHelper
    {
        public static IEnumerable<Game> GetGameSeeds()
        {
            IEnumerable<Game> seedGame = new List<Game>()
            {
                new Game
                {
                    GameId = 1,
                    GameName = "Left for Dead",
                    GameState = "Registration",
                    NwLat = -26.663860,
                    NwLng = 25.283758,
                    SeLat =-16.666860,
                    SeLng =17.966860
                },
                new Game
                {
                    GameId = 2,
                    GameName = "Walking Dead",
                    GameState = "In progress",
                    NwLat = -16.663860,
                    NwLng = 15.283758,
                    SeLat =-6.666860,
                    SeLng =7.966860
                },
                new Game
                {
                    GameId = 3,
                    GameName = "Days Gone",
                    GameState = "Complete",
                    NwLat = -20.263860,
                    NwLng = 21.283358,
                    SeLat =-13.666860,
                    SeLng =12.996860
                }

            };
            return seedGame;
        }

        public static IEnumerable<User> GetUserSeeds()
        {
            IEnumerable<User> seedUser = new List<User>()
            {
                new User
                {
                    UserId = 1,
                    FirstName = "Rebecka",
                    LastName = "Ocampo Sandgren",
                    IsAdmin = false
                },
                new User
                {
                    UserId = 2,
                    FirstName = "Fadi",
                    LastName = "Akkaoui",
                    IsAdmin = true
                },
                new User
                {
                    UserId = 3,
                    FirstName = "Negin",
                    LastName = "Bakhtiarirad",
                    IsAdmin = true
                },
                new User
                {
                    UserId = 4,
                    FirstName = "Betiel",
                    LastName = "Yohannes",
                    IsAdmin = false
                }
            };
            return seedUser;
        }

        public static IEnumerable<Player> GetPlayerSeeds()
        {
            Random rnd = new Random();
            IEnumerable<Player> seedPlayer = new List<Player>()
            {
                new Player
                {
                    PlayerId = 1,
                    IsHuman = true,
                    IsPatientZero = false,
                    BiteCode = rnd.Next(1, 25000),
                    UserId = 1,
                    GameId = 1
                },
                new Player
                {
                    PlayerId = 2,
                    IsHuman = false,
                    IsPatientZero = true,
                    BiteCode = rnd.Next(1, 25000),
                    UserId = 2,
                    GameId = 1
                },
                new Player
                {
                    PlayerId = 3,
                    IsHuman = false,
                    IsPatientZero = false,
                    BiteCode = rnd.Next(1, 25000),
                    UserId = 3,
                    GameId = 2
                },
                new Player
                {
                    PlayerId = 4,
                    IsHuman = true,
                    IsPatientZero = false,
                    BiteCode = rnd.Next(1, 25000),
                    UserId = 4,
                    GameId = 3
                }

            };
            return seedPlayer;
        }
        public static IEnumerable<Squad> GetSquadSeeds()
        {
            IEnumerable<Squad> seedSquad = new List<Squad>()
            {
                new Squad
                {
                    SquadId = 1,
                    SquadName = "Best squad ever",
                    IsHuman = true,
                    GameId = 1
                },
                 new Squad
                {
                    SquadId = 2,
                    SquadName = "Better than best squad",
                    IsHuman = false,
                    GameId = 2
                },
                  new Squad
                {
                    SquadId = 3,
                    SquadName = "Gang gang",
                    IsHuman = false,
                    GameId = 1
                },
                 new Squad
                {
                    SquadId = 4,
                    SquadName = "The beasts",
                    IsHuman = true,
                    GameId = 3
                }

            };
            return seedSquad;
        }
        public static IEnumerable<SquadMember> GetSquadMemberSeeds()
        {
            IEnumerable<SquadMember> seedSquadMember = new List<SquadMember>()
            {
                new SquadMember
                {
                    SquadMemberId = 1,
                    Rank = 4,
                    SquadId = 1,
                    PlayerId = 3
                },
                new SquadMember
                {
                    SquadMemberId = 2,
                    Rank = 5,
                    SquadId = 2,
                    PlayerId = 2
                },
                new SquadMember
                {
                    SquadMemberId = 3,
                    Rank = 1,
                    SquadId = 3,
                    PlayerId = 4
                },
                new SquadMember
                {
                    SquadMemberId = 4,
                    Rank = 10,
                    SquadId = 4,
                    PlayerId = 1
                },
            };
            return seedSquadMember;
        }
        public static IEnumerable<SquadCheckin> GetSquadCheckinSeeds()
        {
            IEnumerable<SquadCheckin> seedSquadCheckin = new List<SquadCheckin>()
            {
                new SquadCheckin
                {
                    SquadCheckinId = 1,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(10),
                    Lat = -26.663860,
                    Lng = 25.283758,
                    GameId = 1,
                    SquadId = 1,
                    SquadMemberId = 1

                },
                new SquadCheckin
                {
                    SquadCheckinId = 2,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(10),
                    Lat = -26.663860,
                    Lng = 25.283758,
                    GameId = 2,
                    SquadId = 2,
                    SquadMemberId = 2
                },
                new SquadCheckin
                {
                    SquadCheckinId = 3,
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddMinutes(10),
                    Lat = -26.663860,
                    Lng = 25.283758,
                    GameId = 2,
                    SquadId = 2,
                    SquadMemberId = 2
                },
            };
            return seedSquadCheckin;
        }
        public static IEnumerable<Mission> GetMissionSeeds()
        {
            IEnumerable<Mission> seedMission = new List<Mission>()
            {
                new Mission
                {
                    MissionId = 1,
                    MissionName = "Collect medicine",
                    IsHumanVisible = true,
                    IsZombieVisible = false,
                    Description = "Try your best to collect five types of medicine. Good Luck!",
                    StartTime = new DateTime(2022, 11, 30, 17, 32, 20),
                    EndTime = new DateTime(2022, 11, 30, 18, 32, 20),
                    GameId = 1
                },
                new Mission
                {
                    MissionId = 2,
                    MissionName = "Collect powerpotion",
                    IsHumanVisible = false,
                    IsZombieVisible = true,
                    Description = "Try your best to collect five types of powerpotion. Good Luck!",
                    StartTime = new DateTime(2022, 11, 30, 14, 32, 20),
                    EndTime = new DateTime(2022, 11, 30, 15, 32, 20),
                    GameId = 1
                },
                new Mission
                {
                    MissionId = 3,
                    MissionName = "Collect weapons",
                    IsHumanVisible = true,
                    IsZombieVisible = false,
                    Description = "Try your best to collect as many weapons as possible. Good Luck!",
                    StartTime = new DateTime(2022, 11, 30, 20, 32, 20),
                    EndTime = new DateTime(2022, 11, 30, 21, 32, 20),
                    GameId = 2
                },
            };
            return seedMission;
        }
        public static IEnumerable<Chat> GetChatSeeds()
        {
            IEnumerable<Chat> seedChat = new List<Chat>()
            {
                new Chat
                {
                    ChatId = 1,
                    Message = "glhf",
                    IsHumanGlobal = false,
                    IsZombieGlobal = false,
                    ChatTime = DateTime.Now,
                    GameId = 1,
                    PlayerId = 1,
                },
                new Chat
                {
                    ChatId = 2,
                    Message = "gg",
                    IsHumanGlobal = true,
                    IsZombieGlobal = false,
                    ChatTime = DateTime.Now,
                    GameId = 1,
                    PlayerId = 1,
                    SquadId = 4
                },
            };
            return seedChat;
        }

    }
}
