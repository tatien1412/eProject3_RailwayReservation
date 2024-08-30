using RailwayTransaction.Domain.Entities;
using System.ComponentModel.DataAnnotations;

public class Ticket
{
    [Key]
    public int PnrNo { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public char Gender { get; set; }
    public int TotalPassengers { get; set; }

    // Foreign key
    public int ReservationID { get; set; }
    public Reservation Reservation { get; set; }
}
