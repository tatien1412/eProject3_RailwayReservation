using Azure.Core;
using MediatR;
using RailwayTransaction.Application.Queries.Admin;
using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories;

namespace RailwayTransaction.Handler.Admin
{
    public class GetUserDetailQueryHandler : IRequestHandler<GetUserDetailQuery, AppUser>
    {
        private readonly IRepository<AppUser, string> _repository;
        public GetUserDetailQueryHandler(IRepository<AppUser, string> repository)
        {
            _repository = repository;
        }

        public async Task<AppUser> Handle(GetUserDetailQuery query, CancellationToken cancellationToken)
        {
            var user = await _repository.GetByIdAsync(query.Id);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user;
        }
    }
}
