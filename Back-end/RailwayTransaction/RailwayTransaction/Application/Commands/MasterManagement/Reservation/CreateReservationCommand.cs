using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Reservation
{
    public class CreateReservationCommand : IRequest<int>
    {
        public int PnrNo { get; set; }
        public string DateOfJourney { get; set; }
        public decimal TotalFare { get; set; }  // Tổng tiền vé

    }
}
