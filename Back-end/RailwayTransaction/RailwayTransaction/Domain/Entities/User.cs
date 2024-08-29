using RailwayTransaction.Domain.Entities;

public class User
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Role { get; set; }
    public string AccessLevel { get; set; }

    // Navigation property
    public ICollection<Reservation> Reservations { get; set; }
}
