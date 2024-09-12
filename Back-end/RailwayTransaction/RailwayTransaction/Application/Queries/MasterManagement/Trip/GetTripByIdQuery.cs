using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Trip
{
    public class GetTripByIdQuery : IRequest<Domain.Entities.Trip>
    {
        public int TripID { get; set; }

        public GetTripByIdQuery(int tripID)
        {
            TripID = tripID;
        }
    }
}
