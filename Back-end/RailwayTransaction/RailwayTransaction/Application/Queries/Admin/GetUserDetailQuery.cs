using MediatR;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Application.Queries.Admin
{
    public class GetUserDetailQuery : IRequest<UserDetail>
    {
        public string? Id { get; set; }
    }
}
