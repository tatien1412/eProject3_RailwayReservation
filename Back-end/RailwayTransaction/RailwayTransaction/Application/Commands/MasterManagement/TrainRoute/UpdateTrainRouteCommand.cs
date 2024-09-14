using MediatR;
using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Application.Commands.MasterManagement.TrainRoute
{
    public class UpdateTrainRouteCommand : IRequest
    {
        public int TrainRouteID { get; set; }
        public string TrainRouteName { get; set; }

    }
}
