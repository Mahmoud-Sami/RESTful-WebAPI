﻿// <auto-generated />
using System;
using HardCode.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HardCode.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220427154931_Intial")]
    partial class Intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("HardCode.Domain.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "IT Department",
                            Name = "IT"
                        },
                        new
                        {
                            Id = 2,
                            Description = "HR Department",
                            Name = "HR"
                        });
                });

            modelBuilder.Entity("HardCode.Domain.Entities.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Instructors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateTime(1998, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentID = 1,
                            Name = "Mahmoud Sami"
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateTime(1997, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepartmentID = 2,
                            Name = "AbdelRahman Hindi"
                        });
                });

            modelBuilder.Entity("HardCode.Domain.Entities.Instructor", b =>
                {
                    b.HasOne("HardCode.Domain.Entities.Department", "Department")
                        .WithMany("Instructors")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HardCode.Domain.Entities.Department", b =>
                {
                    b.Navigation("Instructors");
                });
#pragma warning restore 612, 618
        }
    }
}
