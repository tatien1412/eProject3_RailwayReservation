using RailwayTransaction.Domain.Entities;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }  // Keep Role, remove AccessLevel

    // Navigation property
    public ICollection<Reservation> Reservations { get; set; }
}
