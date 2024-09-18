using MediatR;
using RailwayTransaction.Domain.Entities.Dtos;

namespace RailwayTransaction.Application.Queries.Admin
{
    public class GetAllRolesQuery : IRequest<List<RoleResponse>>
    {
    }
}
