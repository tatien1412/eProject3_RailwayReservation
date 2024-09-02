using MediatR;
using Microsoft.AspNetCore.Identity;
using RailwayTransaction.Application.Queries.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RailwayTransaction.Handler.Admin
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDetail>>
    {
        private readonly IRepository<AppUser, string> _appUserRepository;
        private readonly UserManager<AppUser> _userManager;

        public GetAllUsersQueryHandler(IRepository<AppUser, string> appUserRepository, UserManager<AppUser> userManager)
        {
            _appUserRepository = appUserRepository;
            _userManager = userManager;
        }

        public async Task<List<UserDetail>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _appUserRepository.GetAllAsync();
            var userDetailList = new List<UserDetail>();

            foreach (var user in users)
            {
                var role = await _userManager.GetRolesAsync(user);
                var userDetail = new UserDetail
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    Email = user.Email,
                    Role = string.Join(", ", role),
                };

                userDetailList.Add(userDetail);
            }

            return userDetailList;
        }
    }
}
