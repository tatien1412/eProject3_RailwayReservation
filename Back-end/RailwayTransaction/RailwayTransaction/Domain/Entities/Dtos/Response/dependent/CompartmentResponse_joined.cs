using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class CompartmentResponse_joined
    {
        public int CompartmentID { get; set; }
        public int TrainID { get; set; }
        public string CompartmentType { get; set; } 
        public string SeatType { get; set; }
        public int NumberOfSeats { get; set; }
        public TrainResponse Train { get; set; }
        public ICollection<SeatResponse> Seats { get; set; }


    }
}