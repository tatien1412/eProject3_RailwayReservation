using Microsoft.AspNetCore.Identity;

namespace RailwayTransaction.Domain.Entities.Dtos
{
    public class AppUser : IdentityUser
    {
        public string? FullName { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
