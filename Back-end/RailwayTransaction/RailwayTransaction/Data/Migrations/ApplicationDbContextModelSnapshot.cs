﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RailwayTransaction.Data.Configuration;

#nullable disable

namespace RailwayTransaction.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Fare", b =>
                {
                    b.Property<int>("FareID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FareID"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("CompartmentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<string>("TrainType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FareID");

                    b.HasIndex("ReservationID")
                        .IsUnique();

                    b.ToTable("Fares");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Passenger", b =>
                {
                    b.Property<int>("PassengerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PassengerID"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CoachNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PnrNo")
                        .HasColumnType("int");

                    b.Property<string>("SeatNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PassengerID");

                    b.HasIndex("PnrNo");

                    b.ToTable("Passengers");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.Property<int>("ReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReservationID"));

                    b.Property<string>("CancellationStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CoachNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfJourney")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fare")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("FromStationID")
                        .HasColumnType("int");

                    b.Property<int>("PnrNo")
                        .HasColumnType("int");

                    b.Property<int>("ScheduleID")
                        .HasColumnType("int");

                    b.Property<int?>("ScheduleID1")
                        .HasColumnType("int");

                    b.Property<string>("SeatNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToStationID")
                        .HasColumnType("int");

                    b.Property<int>("TrainNo")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ReservationID");

                    b.HasIndex("FromStationID");

                    b.HasIndex("ScheduleID");

                    b.HasIndex("ScheduleID1");

                    b.HasIndex("ToStationID");

                    b.HasIndex("TrainNo");

                    b.HasIndex("UserID");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Schedule", b =>
                {
                    b.Property<int>("ScheduleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScheduleID"));

                    b.Property<TimeSpan>("ArrivalTime")
                        .HasColumnType("time");

                    b.Property<string>("DayOfWeek")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("DepartureTime")
                        .HasColumnType("time");

                    b.Property<int>("EndStationID")
                        .HasColumnType("int");

                    b.Property<int>("StartStationID")
                        .HasColumnType("int");

                    b.Property<int>("TrainNo")
                        .HasColumnType("int");

                    b.HasKey("ScheduleID");

                    b.HasIndex("TrainNo");

                    b.ToTable("Schedules");
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

                    b.Property<int>("ReservationID")
                        .HasColumnType("int");

                    b.Property<int>("TotalPassengers")
                        .HasColumnType("int");

                    b.HasKey("PnrNo");

                    b.HasIndex("ReservationID");

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

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TrainName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TrainID");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("Station", b =>
                {
                    b.Property<int>("StationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StationID"));

                    b.Property<string>("RailwayDivisionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StationID");

                    b.ToTable("Stations");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Fare", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Reservation", "Reservation")
                        .WithOne("FareDetails")
                        .HasForeignKey("RailwayTransaction.Domain.Entities.Fare", "ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Passenger", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Ticket", "Ticket")
                        .WithMany("Passengers")
                        .HasForeignKey("PnrNo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("Station", "FromStation")
                        .WithMany("FromReservations")
                        .HasForeignKey("FromStationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Schedule", "Schedule")
                        .WithMany()
                        .HasForeignKey("ScheduleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Schedule", null)
                        .WithMany("Reservations")
                        .HasForeignKey("ScheduleID1");

                    b.HasOne("Station", "ToStation")
                        .WithMany("ToReservations")
                        .HasForeignKey("ToStationID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("RailwayTransaction.Domain.Entities.Train", "Train")
                        .WithMany("Reservations")
                        .HasForeignKey("TrainNo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("FromStation");

                    b.Navigation("Schedule");

                    b.Navigation("ToStation");

                    b.Navigation("Train");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Schedule", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Train", "Train")
                        .WithMany("Schedules")
                        .HasForeignKey("TrainNo")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Train");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("RailwayTransaction.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Tickets")
                        .HasForeignKey("ReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reservation");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Reservation", b =>
                {
                    b.Navigation("FareDetails")
                        .IsRequired();

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Schedule", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Ticket", b =>
                {
                    b.Navigation("Passengers");
                });

            modelBuilder.Entity("RailwayTransaction.Domain.Entities.Train", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Schedules");
                });

            modelBuilder.Entity("Station", b =>
                {
                    b.Navigation("FromReservations");

                    b.Navigation("ToReservations");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
