using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Train
{
    public class UpdateTrainCommand : IRequest
    {
        public int TrainID { get; set; }
        public string TrainName { get; set; }
        public string Route { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}
