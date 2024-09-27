using MediatR;

namespace RailwayTransaction.Application.Queries.Staff.Booking
{
    public class DailyCashQuery : IRequest<Domain.Entities.Dtos.Response.dependent.DailyCash_joined>
    {
        public string DateOfTravel {  get; set; }
        public DailyCashQuery(string dateOfTravel)
        {
            DateOfTravel = dateOfTravel;
        }
    }
}
