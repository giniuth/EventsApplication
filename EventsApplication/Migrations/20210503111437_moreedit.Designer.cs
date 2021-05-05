﻿// <auto-generated />
using System;
using EventsApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EventsApplication.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210503111437_moreedit")]
    partial class moreedit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EventsApplication.Models.DecorDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Alcohol")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Catering")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Cuisine")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("EventTypeID")
                        .HasColumnType("int");

                    b.Property<int>("GuestCapacity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventTypeID");

                    b.ToTable("DecorDetails");
                });

            modelBuilder.Entity("EventsApplication.Models.EventType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Budget")
                        .HasColumnType("int");

                    b.Property<int>("CakeSize")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("OccasionName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PictureURL")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("EventTypes");
                });

            modelBuilder.Entity("EventsApplication.Models.DecorDetail", b =>
                {
                    b.HasOne("EventsApplication.Models.EventType", "EventType")
                        .WithMany("DecorDetails")
                        .HasForeignKey("EventTypeID");

                    b.Navigation("EventType");
                });

            modelBuilder.Entity("EventsApplication.Models.EventType", b =>
                {
                    b.Navigation("DecorDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
