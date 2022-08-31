using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Data
{
    public class HvZDbContet : DbContext
    {
        public HvZDbContet(DbContextOptions options) : base(options)
        {
        }

        //Tables
        public DbSet<User> User { get; set;}
        public DbSet<Player> Player { get; set; }
        public DbSet<SquadMember> SquadMember { get; set; }
        public DbSet<Squad> Squad { get; set; }
        public DbSet<SquadCheckin> SquadCheckin { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Kill> Kill { get; set; }
        public DbSet<Chat> Chat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kill>()
                .HasOne(x => x.Victim)
                .WithMany()
                .HasForeignKey(e => e.VictimId);

            modelBuilder.Entity<Kill>()
               .HasOne(x => x.Killer)
               .WithMany()
               .HasForeignKey(e => e.KillerId);
        }


    }
}
