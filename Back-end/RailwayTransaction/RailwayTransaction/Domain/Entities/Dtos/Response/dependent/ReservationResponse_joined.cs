
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class ReservationResponse_joined
    {
        public int ReservationID { get; set; }
        public int PnrNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }
        public TicketResponse Ticket { get; set; }
        public ICollection<SeatResponse> Seats { get; set; }

    }
}
