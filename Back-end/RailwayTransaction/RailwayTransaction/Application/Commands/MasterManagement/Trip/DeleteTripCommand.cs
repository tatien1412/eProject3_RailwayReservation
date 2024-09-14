using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Trip
{
    public class DeleteTripCommand : IRequest
    {
        public int TripID { get; set; }
    }
}
