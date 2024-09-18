using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Identity;
using RailwayTransaction.Application.Queries.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;

namespace RailwayTransaction.Handler.Admin
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, UserDetail>
    {
        private readonly IRepository<AppUser, string> _repository;
        private readonly UserManager<AppUser> _userManager;
        public GetUserDetailQueryHandler(IRepository<AppUser, string> repository, UserManager<AppUser> userManager)
        {
            _repository = repository;
            _userManager = userManager;
        }

        public async Task<UserDetail> Handle(GetUserDetailQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(query.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            var role = await _userManager.GetRolesAsync(user);

            var userDetail = new UserDetail
            {
                Id = user.Id,
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                Password = user.PasswordHash,
                PhoneNumber = user.PhoneNumber,
                Role = string.Join(", ", role)  
            };

            return userDetail;
        }
    }
}
