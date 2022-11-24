﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using iis.Data;

namespace iis.Migrations.SqliteIISDb
{
    [DbContext(typeof(SqliteIISDbContext))]
    [Migration("20221123105557_reset")]
    partial class reset
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("iis.Models.Animal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("About")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Birth")
                        .HasColumnType("TEXT");

                    b.Property<string>("Breed")
                        .HasColumnType("TEXT");

                    b.Property<string>("ChipNumber")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateOfArrival")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ForBeginners")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Friendly")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Reserved")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Size")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Territory")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Animal");
                });

            modelBuilder.Entity("iis.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("OccupationId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("RecruitedDay")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OccupationId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("iis.Models.HealthCondition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Castration")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Handicapped")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Others")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Tattoo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Vaccinated")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId")
                        .IsUnique();

                    b.ToTable("HealthCondition");
                });

            modelBuilder.Entity("iis.Models.Occupation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<double>("Pay")
                        .HasColumnType("REAL");

                    b.Property<int>("Permissions")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Occupation");
                });

            modelBuilder.Entity("iis.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Source")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("iis.Models.VeterinaryRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Details")
                        .HasColumnType("TEXT");

                    b.Property<double>("Weight")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.ToTable("VeterinaryRecord");
                });

            modelBuilder.Entity("iis.Models.Volunteer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Phone")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Verified")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Volunteer");
                });

            modelBuilder.Entity("iis.Models.Walk", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AnimalId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FinishTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("TEXT");

                    b.Property<int>("State")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AnimalId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Walk");
                });

            modelBuilder.Entity("iis.Models.Employee", b =>
                {
                    b.HasOne("iis.Models.Occupation", "Occupation")
                        .WithMany("Employees")
                        .HasForeignKey("OccupationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Occupation");
                });

            modelBuilder.Entity("iis.Models.HealthCondition", b =>
                {
                    b.HasOne("iis.Models.Animal", "Animal")
                        .WithOne("HealthCondition")
                        .HasForeignKey("iis.Models.HealthCondition", "AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("iis.Models.Photo", b =>
                {
                    b.HasOne("iis.Models.Animal", "Animal")
                        .WithMany("Photos")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("iis.Models.VeterinaryRecord", b =>
                {
                    b.HasOne("iis.Models.Animal", "Animal")
                        .WithMany("VeterinaryRecords")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");
                });

            modelBuilder.Entity("iis.Models.Walk", b =>
                {
                    b.HasOne("iis.Models.Animal", "Animal")
                        .WithMany("Walks")
                        .HasForeignKey("AnimalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("iis.Models.Volunteer", "Volunteer")
                        .WithMany("Walks")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Animal");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("iis.Models.Animal", b =>
                {
                    b.Navigation("HealthCondition");

                    b.Navigation("Photos");

                    b.Navigation("VeterinaryRecords");

                    b.Navigation("Walks");
                });

            modelBuilder.Entity("iis.Models.Occupation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("iis.Models.Volunteer", b =>
                {
                    b.Navigation("Walks");
                });
#pragma warning restore 612, 618
        }
    }
}