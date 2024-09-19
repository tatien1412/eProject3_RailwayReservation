using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class SeatResponse_joined
    {
        public int SeatID { get; set; }
        public int CompartmentID { get; set; }
        public string SeatNumber { get; set; }
        public string SeatStatus { get; set; }
        public string SeatType { get; set; } 
        public decimal Fare { get; set; } 
        public int? ReservationID { get; set; }
        public CompartmentResponse Compartment { get; set; }
        public ReservationResponse Reservation { get; set; }
    }
}