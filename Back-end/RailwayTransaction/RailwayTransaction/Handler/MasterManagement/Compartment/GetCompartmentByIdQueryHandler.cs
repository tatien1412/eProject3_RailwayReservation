using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Queries.MasterManagement.Compartment;
using RailwayTransaction.Domain.Entities.Dtos.Mapper;
using RailwayTransaction.Domain.Interface;


namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class GetCompartmentByIdQueryHandler : IRequestHandler<GetCompartmentByIdQuery, Domain.Entities.Dtos.Response.dependent.CompartmentResponse_joined>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Train, int> _trainRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public GetCompartmentByIdQueryHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                                IRepository<Domain.Entities.Train, int> trainRepository,
                                                IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _compartmentRepository = compartmentRepository;
            _trainRepository = trainRepository;
            _seatRepository = seatRepository;
        }

        public async Task<Domain.Entities.Dtos.Response.dependent.CompartmentResponse_joined> Handle(GetCompartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var compartment = await _compartmentRepository.GetByIdAsync(request.CompartmentID);
            if (compartment == null)
            {
                throw new Exception("Compartment not found");
            }
            var train = await _trainRepository.GetByIdAsync(compartment.TrainID);
            List<Domain.Entities.Seat> seats =  (await _seatRepository.GetAllAsync()).ToList();

            return CompartmentMapper.ConvertToResponseAll(compartment, train, seats);
        }

    }
}
