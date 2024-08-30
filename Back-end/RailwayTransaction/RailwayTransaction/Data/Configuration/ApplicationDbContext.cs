using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Domain.Entities;

public class ApplicationDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Fare> Fares { get; set; }
    public DbSet<Station> Stations { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Train> Trains { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reservations)
            .HasForeignKey(r => r.UserID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Train)
            .WithMany(t => t.Reservations)
            .HasForeignKey(r => r.TrainNo)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.FromStation)
            .WithMany(s => s.FromReservations)
            .HasForeignKey(r => r.FromStationID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.ToStation)
            .WithMany(s => s.ToReservations)
            .HasForeignKey(r => r.ToStationID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Schedule)
            .WithMany()
            .HasForeignKey(r => r.ScheduleID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Ticket>()
            .HasOne(t => t.Reservation)
            .WithMany(r => r.Tickets)
            .HasForeignKey(t => t.ReservationID)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(s => s.Train)
            .WithMany(t => t.Schedules)
            .HasForeignKey(s => s.TrainNo)
            .OnDelete(DeleteBehavior.Restrict);

        base.OnModelCreating(modelBuilder);
    }
}
