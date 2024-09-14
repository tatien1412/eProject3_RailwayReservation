using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Seat
{
    public class GetSeatByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.SeatResponse_joined>
    {
        public int SeatID { get; set; }

        public GetSeatByIdQuery(int seatID)
        {
            SeatID = seatID;
        }
    }
}
