using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Trip
{
    public class GetTripByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.TripResponse_joined>
    {
        public int TripID { get; set; }

        public GetTripByIdQuery(int tripID)
        {
            TripID = tripID;
        }
    }
}
