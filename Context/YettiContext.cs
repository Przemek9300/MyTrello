using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trelloApi.Domains;

namespace trelloApi.Context
{
    public class YettiContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Note> Notes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(c => c.Board)
                .WithOne(e => e.User)
                .OnDelete(DeleteBehavior.SetNull);


        }



    }
}

