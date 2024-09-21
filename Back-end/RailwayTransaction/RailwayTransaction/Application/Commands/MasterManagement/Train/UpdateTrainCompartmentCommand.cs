using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Train
{
    public class UpdateTrainCompartmentCommand : IRequest
    {
        public int TrainID { get; set; }
        public int NumberOfCompartments { get; set; }
    }
}
