﻿// <auto-generated />
using CQRS_Project.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CQRS_Project.Migrations
{
    [DbContext(typeof(StudentContext))]
    [Migration("20240706134527_SecondStudentCreate")]
    partial class SecondStudentCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CQRS_Project.Data.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 0,
                            Name = "Sercan",
                            Surname = "Tokyürek"
                        },
                        new
                        {
                            Id = 2,
                            Age = 1,
                            Name = "Nesrin",
                            Surname = "Tokyürek"
                        },
                        new
                        {
                            Id = 3,
                            Age = 1,
                            Name = "Zeki",
                            Surname = "Tokyürek"
                        },
                        new
                        {
                            Id = 4,
                            Age = 1,
                            Name = "Solmaz",
                            Surname = "Tokyürek"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
