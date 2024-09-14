using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.Seat
{
    public class GetAllSeatsQuery : IRequest<List<Domain.Entities.Dtos.Response.independent.SeatResponse>>
    {
    }
}
