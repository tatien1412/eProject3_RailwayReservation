
namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
        public int PnrNo { get; set; }
        public String DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }
    }
}
