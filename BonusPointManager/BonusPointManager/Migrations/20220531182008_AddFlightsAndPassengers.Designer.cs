﻿// <auto-generated />
using System;
using BonusPointManager.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BonusPointManager.Migrations
{
    [DbContext(typeof(BonusPointManagerContext))]
    [Migration("20220531182008_AddFlightsAndPassengers")]
    partial class AddFlightsAndPassengers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccountNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SignupDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StatusLevel")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("EurobonusAccounts");
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusPointType", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("PointType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EurobonusPointTypes");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            PointType = "Extra"
                        },
                        new
                        {
                            Id = 1,
                            PointType = "Basic"
                        },
                        new
                        {
                            Id = 2,
                            PointType = "Status"
                        });
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusStatusLevel", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("StatusLevel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EurobonusStatusLevels");

                    b.HasData(
                        new
                        {
                            Id = 0,
                            StatusLevel = "Basic"
                        },
                        new
                        {
                            Id = 1,
                            StatusLevel = "Silver"
                        },
                        new
                        {
                            Id = 2,
                            StatusLevel = "Gold"
                        },
                        new
                        {
                            Id = 3,
                            StatusLevel = "Diamond"
                        },
                        new
                        {
                            Id = 4,
                            StatusLevel = "Pandion"
                        });
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusTransaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AcquiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PointType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AccountId");

                    b.ToTable("EurobonusTransactions");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Aircraft", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("IcaoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Registration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Aircraft");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Airline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Abbreviation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Callsign")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IataCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IcaoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airlines");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Airport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ElevationFt")
                        .HasColumnType("int");

                    b.Property<string>("IataCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IcaoCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LatitudeDeg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("LongName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("LongitudeDeg")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Airports");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AircraftId")
                        .HasColumnType("int");

                    b.Property<int?>("ArrivalAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ArrivalTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartureAirportId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DepartureTimeUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FlightNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OperatingAirlineId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AircraftId");

                    b.HasIndex("ArrivalAirportId");

                    b.HasIndex("DepartureAirportId");

                    b.HasIndex("OperatingAirlineId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Runway", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AirportId")
                        .HasColumnType("int");

                    b.Property<int>("DisplacedThresholdFt")
                        .HasColumnType("int");

                    b.Property<int>("Heading")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AirportId");

                    b.ToTable("Runways");
                });

            modelBuilder.Entity("BonusPointManager.Models.Person.Passenger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AccountId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.Property<int>("FlightsId")
                        .HasColumnType("int");

                    b.Property<int>("PassengersId")
                        .HasColumnType("int");

                    b.HasKey("FlightsId", "PassengersId");

                    b.HasIndex("PassengersId");

                    b.ToTable("PassengerFlights", (string)null);
                });

            modelBuilder.Entity("BonusPointManager.Models.Eurobonus.EurobonusTransaction", b =>
                {
                    b.HasOne("BonusPointManager.Models.Eurobonus.EurobonusAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Flight", b =>
                {
                    b.HasOne("BonusPointManager.Models.Flights.Aircraft", "Aircraft")
                        .WithMany()
                        .HasForeignKey("AircraftId");

                    b.HasOne("BonusPointManager.Models.Flights.Airport", "ArrivalAirport")
                        .WithMany()
                        .HasForeignKey("ArrivalAirportId");

                    b.HasOne("BonusPointManager.Models.Flights.Airport", "DepartureAirport")
                        .WithMany()
                        .HasForeignKey("DepartureAirportId");

                    b.HasOne("BonusPointManager.Models.Flights.Airline", "OperatingAirline")
                        .WithMany()
                        .HasForeignKey("OperatingAirlineId");

                    b.Navigation("Aircraft");

                    b.Navigation("ArrivalAirport");

                    b.Navigation("DepartureAirport");

                    b.Navigation("OperatingAirline");
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Runway", b =>
                {
                    b.HasOne("BonusPointManager.Models.Flights.Airport", null)
                        .WithMany("Runways")
                        .HasForeignKey("AirportId");
                });

            modelBuilder.Entity("BonusPointManager.Models.Person.Passenger", b =>
                {
                    b.HasOne("BonusPointManager.Models.Eurobonus.EurobonusAccount", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId");

                    b.Navigation("Account");
                });

            modelBuilder.Entity("FlightPassenger", b =>
                {
                    b.HasOne("BonusPointManager.Models.Flights.Flight", null)
                        .WithMany()
                        .HasForeignKey("FlightsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BonusPointManager.Models.Person.Passenger", null)
                        .WithMany()
                        .HasForeignKey("PassengersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BonusPointManager.Models.Flights.Airport", b =>
                {
                    b.Navigation("Runways");
                });
#pragma warning restore 612, 618
        }
    }
}
