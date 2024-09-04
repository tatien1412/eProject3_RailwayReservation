using MediatR;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Application.Queries.Admin
{
    public class GetAllUsersQuery : IRequest<List<UserDetail>>
    {
    }
}
