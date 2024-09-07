using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Fare
{
    public class GetFareByIdQuery : IRequest<Domain.Entities.Fare>
    {
        public int FareID { get; set; }

        public GetFareByIdQuery(int fareID)
        {
            FareID = fareID;
        }
    }
}
