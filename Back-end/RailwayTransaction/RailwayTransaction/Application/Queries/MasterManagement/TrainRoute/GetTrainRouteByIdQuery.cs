using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.TrainRoute
{
    public class GetTrainRouteByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.TrainRouteResponse_joined>
    {
        public int trainRouteID { get; set; }

        public GetTrainRouteByIdQuery(int trainRouteID)
        {
            this.trainRouteID = trainRouteID;
        }
    }
}
