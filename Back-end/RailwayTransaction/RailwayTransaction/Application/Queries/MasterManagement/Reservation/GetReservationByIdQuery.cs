using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Reservation
{
    public class GetReservationByIdQuery : IRequest<Domain.Entities.Reservation>
    {
        public int ReservationID { get; set; }

        public GetReservationByIdQuery(int reservationID)
        {
            ReservationID = reservationID;
        }
    }
}
