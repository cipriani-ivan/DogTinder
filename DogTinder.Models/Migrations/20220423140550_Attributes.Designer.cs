﻿// <auto-generated />
using System;
using DogTinder.EFDataAccessLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DogTinder.Models.Migrations
{
    [DbContext(typeof(DogTinderContext))]
    [Migration("20220423140550_Attributes")]
    partial class Attributes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DogTinder.Models.Appointment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("PlaceID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("PlaceID");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("DogTinder.Models.Dog", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AppointmentID")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("OwnerID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AppointmentID");

                    b.HasIndex("OwnerID");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("DogTinder.Models.Owner", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("DogTinder.Models.Place", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ID");

                    b.ToTable("Places");
                });

            modelBuilder.Entity("DogTinder.Models.Appointment", b =>
                {
                    b.HasOne("DogTinder.Models.Place", "Place")
                        .WithMany()
                        .HasForeignKey("PlaceID");

                    b.Navigation("Place");
                });

            modelBuilder.Entity("DogTinder.Models.Dog", b =>
                {
                    b.HasOne("DogTinder.Models.Appointment", null)
                        .WithMany("Dog")
                        .HasForeignKey("AppointmentID");

                    b.HasOne("DogTinder.Models.Owner", null)
                        .WithMany("Dog")
                        .HasForeignKey("OwnerID");
                });

            modelBuilder.Entity("DogTinder.Models.Appointment", b =>
                {
                    b.Navigation("Dog");
                });

            modelBuilder.Entity("DogTinder.Models.Owner", b =>
                {
                    b.Navigation("Dog");
                });
#pragma warning restore 612, 618
        }
    }
}
