using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Reservation
{
    public class GetAllReservationsQuery : IRequest<List<Domain.Entities.Reservation>>
    {
    }
}
