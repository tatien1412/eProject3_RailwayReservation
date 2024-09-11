using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.TrainRoute
{
    public class DeleteTrainRouteCommand : IRequest
    {
        public int TrainRouteID { get; set; }
    }
}
