﻿// <auto-generated />
using System;
using FestményAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FestményAPI.Migrations
{
    [DbContext(typeof(FestményAPIContext))]
    partial class FestményAPIContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FestményAPI.Model.Berles", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("dailyPrice")
                        .HasColumnType("int");

                    b.Property<DateTime>("endDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("paintingId")
                        .HasColumnType("int");

                    b.Property<DateTime>("startDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("uid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Berles");
                });
#pragma warning restore 612, 618
        }
    }
}
