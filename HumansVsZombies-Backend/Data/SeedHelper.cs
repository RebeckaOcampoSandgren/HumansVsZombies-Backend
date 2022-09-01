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

    }
}
