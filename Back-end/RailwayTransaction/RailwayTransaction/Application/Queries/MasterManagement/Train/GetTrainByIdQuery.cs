using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Train
{
    public class GetTrainByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.TrainResponse_joined>
    {
        public int TrainID { get; set; }

        public GetTrainByIdQuery(int trainID)
        {
            TrainID = trainID;
        }
    }
}
