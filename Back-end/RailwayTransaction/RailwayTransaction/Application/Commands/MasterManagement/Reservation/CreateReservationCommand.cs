using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Reservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public int TripID { get; set; }
        public int PnrNo { get; set; }
        public DateTime DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }  // Tổng tiền vé

    }
}
