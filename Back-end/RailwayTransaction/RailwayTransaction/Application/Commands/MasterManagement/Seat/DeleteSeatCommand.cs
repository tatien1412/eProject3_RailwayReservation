using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Seat
{
    public class DeleteSeatCommand : IRequest
    {
        public int SeatID { get; set; }
    }
}
