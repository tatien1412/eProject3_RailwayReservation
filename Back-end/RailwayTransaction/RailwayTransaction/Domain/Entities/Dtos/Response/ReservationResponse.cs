
namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class ReservationResponse
    {
        public int ReservationID { get; set; }
        public int PnrNo { get; set; }
        public string SeatNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public string CoachNo { get; set; }
        public string CancellationStatus { get; set; }
    }
}
