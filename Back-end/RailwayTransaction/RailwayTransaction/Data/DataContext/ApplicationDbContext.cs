using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Data.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Các DbSet tương ứng với các entity đã tạo
        public DbSet<TrainRoute> TrainRoutes { get; set; }
        public DbSet<RouteStation> RouteStations { get; set; }
        public DbSet<Station> Stations { get; set; }
        public DbSet<Train> Trains { get; set; }
        public DbSet<Compartment> Compartments { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình cho các quan hệ giữa các bảng, bao gồm khóa ngoại và các quan hệ 1-n, n-n

            // 1. TrainRoute - RouteStation: Một tuyến đường (TrainRoute) có nhiều ga (RouteStation)
            modelBuilder.Entity<TrainRoute>()
                .HasMany(r => r.RouteStations)
                .WithOne(rs => rs.TrainRoute)
                .HasForeignKey(rs => rs.TrainRouteID)
                .OnDelete(DeleteBehavior.Cascade);

            // 2. RouteStation - Station: Một Station có thể thuộc nhiều RouteStation
            modelBuilder.Entity<RouteStation>()
                .HasOne(rs => rs.Station)  // Mỗi RouteStation có một Station
                .WithMany(s => s.RouteStations)  // Một Station có nhiều RouteStations
                .HasForeignKey(rs => rs.StationID)
                .OnDelete(DeleteBehavior.Restrict);


         
            // 4. Train - Compartment: Một tàu (Train) có nhiều khoang (Compartment)
            modelBuilder.Entity<Train>()
                .HasMany(t => t.Compartments)
                .WithOne(c => c.Train)
                .HasForeignKey(c => c.TrainID)
                .OnDelete(DeleteBehavior.Cascade);

            // 5. Compartment - Seat: Một khoang (Compartment) có nhiều ghế (Seat)
            modelBuilder.Entity<Compartment>()
                .HasMany(c => c.Seats)
                .WithOne(s => s.Compartment)
                .HasForeignKey(s => s.CompartmentID)
                .OnDelete(DeleteBehavior.Cascade);

            // 6. Reservation - Seat: Một đặt chỗ (Reservation) có thể đặt nhiều ghế (Seat)
            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Seats)
                .WithOne(s => s.Reservation)
                .HasForeignKey(s => s.ReservationID)
                .OnDelete(DeleteBehavior.Restrict);

            // 8. Trip - Station: Liên kết giữa Trip và ga xuất phát/ga đến
            modelBuilder.Entity<Trip>()
                .HasOne(t => t.StartStation)
                .WithMany()
                .HasForeignKey(t => t.StartStationID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.EndStation)
                .WithMany()
                .HasForeignKey(t => t.EndStationID)
                .OnDelete(DeleteBehavior.Restrict);


            //9. Cấu hình quan hệ giữa Schedule và Train
            modelBuilder.Entity<Schedule>()
                .HasOne(s => s.Train)
                .WithMany(t => t.Schedules)
                .HasForeignKey(s => s.TrainID)
                .OnDelete(DeleteBehavior.Cascade);  // Hoặc sử dụng DeleteBehavior.NoAction để tránh vòng lặp
        }
    }
}
