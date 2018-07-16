﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using trelloApi.Context;

namespace trelloApi.Migrations
{
    [DbContext(typeof(YettiContext))]
    partial class YettiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("trelloApi.Domains.Board", b =>
                {
                    b.Property<Guid>("BoardId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("GroupId");

                    b.Property<string>("Title");

                    b.HasKey("BoardId");

                    b.HasIndex("GroupId");

                    b.ToTable("Boards");
                });

            modelBuilder.Entity("trelloApi.Domains.Group", b =>
                {
                    b.Property<Guid>("GroupId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<Guid?>("OwnerUserId");

                    b.HasKey("GroupId");

                    b.HasIndex("OwnerUserId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("trelloApi.Domains.GroupUser", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("GroupId");

                    b.HasKey("UserId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupUser");
                });

            modelBuilder.Entity("trelloApi.Domains.Note", b =>
                {
                    b.Property<Guid>("NoteId")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("BoardId");

                    b.Property<bool>("Completed");

                    b.Property<string>("Description");

                    b.Property<bool>("Hide");

                    b.HasKey("NoteId");

                    b.HasIndex("BoardId");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("trelloApi.Domains.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<string>("Email");

                    b.Property<string>("HashPassword");

                    b.Property<string>("Salt");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("trelloApi.Domains.Board", b =>
                {
                    b.HasOne("trelloApi.Domains.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("trelloApi.Domains.Group", b =>
                {
                    b.HasOne("trelloApi.Domains.User", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerUserId");
                });

            modelBuilder.Entity("trelloApi.Domains.GroupUser", b =>
                {
                    b.HasOne("trelloApi.Domains.User", "User")
                        .WithMany("GroupUser")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("trelloApi.Domains.Group", "Group")
                        .WithMany("GroupUser")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("trelloApi.Domains.Note", b =>
                {
                    b.HasOne("trelloApi.Domains.Board", "Board")
                        .WithMany("Notes")
                        .HasForeignKey("BoardId");
                });
#pragma warning restore 612, 618
        }
    }
}
