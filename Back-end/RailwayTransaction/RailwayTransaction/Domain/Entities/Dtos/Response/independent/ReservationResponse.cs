
namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
        public int PnrNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }
    }
}
