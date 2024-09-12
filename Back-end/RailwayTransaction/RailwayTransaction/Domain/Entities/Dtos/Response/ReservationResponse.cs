
namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class ReservationResponse
    {
        public int TripID { get; set; }
        public int PnrNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }  // Tổng tiền vé
    }
}
