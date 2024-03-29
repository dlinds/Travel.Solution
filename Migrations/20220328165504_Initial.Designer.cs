﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Travel.Models;

namespace Travel.Solution.Migrations
{
#pragma warning disable CS1591
  [DbContext(typeof(TravelContext))]
  [Migration("20220328165504_Initial")]
  partial class Initial
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("Relational:MaxIdentifierLength", 64)
          .HasAnnotation("ProductVersion", "5.0.0");

      modelBuilder.Entity("Travel.Models.Destination", b =>
          {
            b.Property<int>("DestinationId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("City")
                      .HasColumnType("longtext CHARACTER SET utf8mb4");

            b.Property<string>("Country")
                      .HasColumnType("longtext CHARACTER SET utf8mb4");

            b.Property<string>("Name")
                      .HasColumnType("longtext CHARACTER SET utf8mb4");

            b.Property<int>("NumOfReviews")
                      .HasColumnType("int");

            b.Property<float>("Rating")
                      .HasColumnType("float");

            b.HasKey("DestinationId");

            b.ToTable("Destinations");
          });
#pragma warning restore 612, 618
    }
  }
#pragma warning restore CS1591
}
