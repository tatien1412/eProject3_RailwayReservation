using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Train
{
    public class DeleteTrainCommand : IRequest
    {
        public int TrainID { get; set; }
    }
}
