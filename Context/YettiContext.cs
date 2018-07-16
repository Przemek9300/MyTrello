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
        public DbSet<Group> Groups { get; set; }

        public DbSet<Board> Boards { get; set; }

        public DbSet<Note> Notes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GroupUser>()
          .HasKey(pc => new { pc.UserId, pc.GroupId });

            modelBuilder.Entity<GroupUser>()
                .HasOne(pc => pc.User)
                .WithMany(p => p.GroupUser)
                .HasForeignKey(pc => pc.GroupId);


            modelBuilder.Entity<GroupUser>()
                .HasOne(pc => pc.Group)
                .WithMany(p => p.GroupUser)
                .HasForeignKey(pc => pc.UserId);

        }
    }
}
