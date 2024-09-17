using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class CompartmentResponse
    {
        public int CompartmentID { get; set; }
        public int TrainID { get; set; }
        public string CompartmentType { get; set; }  
        public string SeatType { get; set; }
        public int NumberOfSeats { get; set; }

    }
}