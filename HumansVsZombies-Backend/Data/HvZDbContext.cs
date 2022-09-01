using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Data
{
    public class HvZDbContext : DbContext
    {
        public HvZDbContext(DbContextOptions options) : base(options)
        {
        }

        //Tables
        public DbSet<User> User { get; set;}
        public DbSet<Squad> Squad { get; set; }
        public DbSet<SquadCheckin> SquadCheckin { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Mission> Mission { get; set; }
        public DbSet<Chat> Chat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relationship one-to-many SquadMember-Squad
            modelBuilder.Entity<SquadMember>()
                .HasOne<Squad>(s => s.Squad)
                .WithMany(sq => sq.SquadMembers)
                .HasForeignKey(e => e.SquadId)
                .OnDelete(DeleteBehavior.Restrict);

            ////Relationship one-to-many SquadMember-player
            //modelBuilder.Entity<SquadMember>()
            //     .HasOne<Player>(s => s.Player)
            //     .WithMany(sq => sq.SquadMembers)
            //     .HasForeignKey(e => e.PlayerId)
            //     .OnDelete(DeleteBehavior.Restrict);

            ////Relationship one-to-many Chat-player
            modelBuilder.Entity<Chat>()
               .HasOne<Player>(p => p.Player)
               .WithMany(pl => pl.Chats)
               .HasForeignKey(e => e.PlayerId)
               .OnDelete(DeleteBehavior.Restrict);

            ////Relationship one-to-many Chat-Squad
            modelBuilder.Entity<Chat>()
               .HasOne<Squad>(s => s.Squad)
               .WithMany(c => c.Chats)
               .HasForeignKey(e => e.SquadId)
               .OnDelete(DeleteBehavior.Restrict);

            ////Relationship one-to-many SquadChechin-Squad
            modelBuilder.Entity<SquadCheckin>()
                .HasOne<Squad>(s => s.Squad)
                .WithMany(sq => sq.SquadCheckins)
                .HasForeignKey(e => e.SquadId)
                .OnDelete(DeleteBehavior.Restrict);

            ////Relationship one-to-many SquadChechin-SquadMember
            modelBuilder.Entity<SquadCheckin>()
                .HasOne<SquadMember>(s => s.SquadMember)
                .WithMany(sq => sq.SquadCheckins)
                .HasForeignKey(e => e.SquadMemberId)
                .OnDelete(DeleteBehavior.Restrict);

            //Relationship one-to-many SquadChechin-Game
            //modelBuilder.Entity<SquadCheckin>()
            //   .HasOne<Game>(s => s.Game)
            //   .WithMany(sq => sq.SquadCheckins)
            //   .HasForeignKey(e => e.GameId)
            //   .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<HumansVsZombies_Backend.Models.Player> Player { get; set; }

        public DbSet<HumansVsZombies_Backend.Models.SquadMember> SquadMember { get; set; }
    }
}
