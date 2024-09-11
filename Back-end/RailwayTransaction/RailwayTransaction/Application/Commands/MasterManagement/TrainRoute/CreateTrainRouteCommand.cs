using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.TrainRoute
{
    public class CreateTrainRouteCommand : IRequest<int>
    {
        public string TrainRouteName { get; set; }
    }
}
