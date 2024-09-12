using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Reservation
{
    public class DeleteReservationCommand : IRequest
    {
        public int ReservationID { get; set; }
    }
}
