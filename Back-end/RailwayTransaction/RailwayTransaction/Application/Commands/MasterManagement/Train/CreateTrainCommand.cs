using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Train
{
    public class CreateTrainCommand : IRequest<int>
    {
        public string TrainName { get; set; }
        public string TrainStatus { get; set; }
        public int TrainRouteID { get; set; }
        public int NumberOfCompartments { get; set; } 
    }
}
