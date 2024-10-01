using MediatR;

namespace RailwayTransaction.Application.Queries.Staff.Booking
{
    public class AvailabelseatQuery : IRequest<Domain.Entities.Dtos.Response.StaffReponse.AvailabelSeatReponse>
    {
        public int TrainId {  get; set; }
        public AvailabelseatQuery(int trainId) {
           
            TrainId = trainId;
        }
    }
}
