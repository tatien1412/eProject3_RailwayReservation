using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class SeatResponse
    {
        public int SeatID { get; set; }
        public int CompartmentID { get; set; }
        public string SeatNumber { get; set; }
        public string SeatStatus { get; set; }
        public string SeatType { get; set; } 
        public decimal Fare { get; set; } 
        public int? ReservationID { get; set; }
    }
}