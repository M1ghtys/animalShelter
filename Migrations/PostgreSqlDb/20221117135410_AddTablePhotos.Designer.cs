﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using iis.Data;

namespace iis.Migrations.PostgreSqlDb
{
    [DbContext(typeof(PostgreSqlDbContext))]
    [Migration("20221117135410_AddTablePhotos")]
    partial class AddTablePhotos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("iis.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("About")
                        .HasColumnType("text");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Breed")
                        .HasColumnType("text");

                    b.Property<string>("ChipNumber")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("ForBeginners")
                        .HasColumnType("boolean");

                    b.Property<int>("Friendly")
                        .HasColumnType("integer");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<bool>("Reserved")
                        .HasColumnType("boolean");

                    b.Property<int>("Size")
                        .HasColumnType("integer");

                    b.Property<int>("Territory")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("iis.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OccupationId")
                        .HasColumnType("integer");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<DateTime>("RecruitedDay")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("iis.Models.HealthCondition", b =>
                {
                    b.Property<int>("AnimalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("Castration")
                        .HasColumnType("boolean");

                    b.Property<bool>("Handicapped")
                        .HasColumnType("boolean");

                    b.Property<string>("Others")
                        .HasColumnType("text");

                    b.Property<bool>("Tattoo")
                        .HasColumnType("boolean");

                    b.Property<bool>("Vaccinated")
                        .HasColumnType("boolean");

                    b.HasKey("AnimalId");

                    b.ToTable("HealthCondition");
                });

            modelBuilder.Entity("iis.Models.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Pay")
                        .HasColumnType("double precision");

                    b.Property<int>("Permissions")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Occupation");
                });

            modelBuilder.Entity("iis.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<string>("Source")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("iis.Models.VeterinaryRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<double>("Weight")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.ToTable("VeterinaryRecord");
                });

            modelBuilder.Entity("iis.Models.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<bool>("Verified")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("iis.Models.Walk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AnimalId")
                        .HasColumnType("integer");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("State")
                        .HasColumnType("integer");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Walk");
                });
#pragma warning restore 612, 618
        }
    }
}
