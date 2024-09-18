using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RailwayTransaction.Handler.Admin
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, List<RoleResponse>>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public GetAllRolesQueryHandler(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<List<RoleResponse>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {
            var roles = await _roleManager.Roles.ToListAsync();
            var roleResponseList = new List<RoleResponse>();

            foreach (var role in roles)
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(role.Name!);
                var roleResponse = new RoleResponse
                {
                    Id = role.Id,
                    Name = role.Name,
                    TotalUsers = usersInRole.Count
                };

                roleResponseList.Add(roleResponse);
            }

            return roleResponseList;
        }
    }
}
