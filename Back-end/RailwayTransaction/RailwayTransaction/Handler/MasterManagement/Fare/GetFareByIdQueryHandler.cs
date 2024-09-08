using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Fare;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Fare
{
    public class GetFareByIdQueryHandler : IRequestHandler<GetFareByIdQuery, Domain.Entities.Fare>
    {
        private readonly IRepository<Domain.Entities.Fare, int> _fareRepository;

        public GetFareByIdQueryHandler(IRepository<Domain.Entities.Fare, int> fareRepository)
        {
            _fareRepository = fareRepository;
        }

        public async Task<Domain.Entities.Fare> Handle(GetFareByIdQuery request, CancellationToken cancellationToken)
        {
            var fare = await _fareRepository.GetByIdAsync(request.FareID);

            if (fare == null)
            {
                throw new Exception("Fare not found");
            }

            return fare;
        }
    }
}
