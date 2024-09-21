﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayTransaction.Data.DataContext;

#nullable disable

namespace RailwayTransaction.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240921035212_cash_database")]
    partial class cash_database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.CashTransaction", b =>
                {
                    b.Property<int>("CashTransactionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CashTransactionID"));

                    b.Property<decimal>("CashReceived")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CashRefunded")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("DateOftransaction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CashTransactionID");

                    b.ToTable("CashTransactions");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Compartment", b =>
                {
                    b.Property<int>("CompartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompartmentID"));

                    b.Property<string>("CompartmentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<string>("SeatType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("TrainID")
                        .HasColumnType("int");

                    b.HasKey("CompartmentID");

                    b.HasIndex("TrainID");

                    b.ToTable("Compartments");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Dtos.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("CashTransactionID")
                        .HasColumnType("int");

                    b.Property<string>("DateOfJourney")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PnrNo")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalFare")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ReservationID");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CashTransactionID");

                    b.HasIndex("PnrNo");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.RouteStation", b =>
                {
                    b.Property<int>("RouteStationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RouteStationID"));

                    b.Property<int>("OrderInRoute")
                        .HasColumnType("int");

                    b.Property<int>("StationID")
                        .HasColumnType("int");

                    b.Property<int>("TrainRouteID")
                        .HasColumnType("int");

                    b.HasKey("RouteStationID");

                    b.HasIndex("StationID");

                    b.HasIndex("TrainRouteID");

                    b.ToTable("RouteStations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<string>("ArrivalTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DepartureTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainID")
                        .HasColumnType("int");

                    b.HasKey("ScheduleID");

                    b.HasIndex("TrainID");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Seat", b =>
                {
                    b.Property<int>("SeatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeatID"));

                    b.Property<int>("CompartmentID")
                        .HasColumnType("int");

                    b.Property<decimal>("Fare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("ReservationID")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SeatStatus")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("SeatID");

                    b.HasIndex("CompartmentID");

                    b.HasIndex("ReservationID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Station", b =>
                {
                    b.Property<int>("StationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationID"));

                    b.Property<string>("RailwayDivisionName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("StationCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("StationID");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Ticket", b =>
                {
                    b.Property<int>("PnrNo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PnrNo"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalPassengers")
                        .HasColumnType("int");

                    b.HasKey("PnrNo");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Train", b =>
                {
                    b.Property<int>("TrainID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainID"));

                    b.Property<int>("NumberOfCompartments")
                        .HasColumnType("int");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("TrainRouteID")
                        .HasColumnType("int");

                    b.Property<string>("TrainStatus")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("TrainID");

                    b.HasIndex("TrainRouteID");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.TrainRoute", b =>
                {
                    b.Property<int>("TrainRouteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrainRouteID"));

                    b.Property<string>("TrainRouteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("TrainRouteID");

                    b.ToTable("TrainRoutes");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Trip", b =>
                {
                    b.Property<int>("TripID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TripID"));

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<int>("EndStationID")
                        .HasColumnType("int");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<int>("StartStationID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("TravelTime")
                        .HasColumnType("time");

                    b.HasKey("TripID");

                    b.HasIndex("EndStationID");

                    b.HasIndex("ReservationID");

                    b.HasIndex("ScheduleID");

                    b.HasIndex("StartStationID");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Dtos.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Dtos.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Dtos.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Dtos.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Compartment", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Train", "Train")
                        .WithMany("Compartments")
                        .HasForeignKey("TrainID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Dtos.AppUser", null)
                        .WithMany("Reservations")
                        .HasForeignKey("AppUserId");

                    b.HasOne("RailwayTransaction.Domain.Entities.CashTransaction", "CashTransaction")
                        .WithMany("Reservations")
                        .HasForeignKey("CashTransactionID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RailwayTransaction.Domain.Entities.Ticket", "Ticket")
                        .WithMany()
                        .HasForeignKey("PnrNo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CashTransaction");

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.RouteStation", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Station", "Station")
                        .WithMany("RouteStations")
                        .HasForeignKey("StationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.TrainRoute", "TrainRoute")
                        .WithMany("RouteStations")
                        .HasForeignKey("TrainRouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");

                    b.Navigation("TrainRoute");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Train", "Train")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Seat", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Compartment", "Compartment")
                        .WithMany("Seats")
                        .HasForeignKey("CompartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Seats")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Compartment");

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Train", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.TrainRoute", "TrainRoute")
                        .WithMany()
                        .HasForeignKey("TrainRouteID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrainRoute");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Trip", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Station", "EndStation")
                        .WithMany()
                        .HasForeignKey("EndStationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Reservation", "Reservation")
                        .WithMany()
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Station", "StartStation")
                        .WithMany()
                        .HasForeignKey("StartStationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("EndStation");

                    b.Navigation("Reservation");

                    b.Navigation("Schedule");

                    b.Navigation("StartStation");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.CashTransaction", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Compartment", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Dtos.AppUser", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.Navigation("Seats");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Station", b =>
                {
                    b.Navigation("RouteStations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Train", b =>
                {
                    b.Navigation("Compartments");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.TrainRoute", b =>
                {
                    b.Navigation("RouteStations");
                });
#pragma warning restore 612, 618
        }
    }
}
