using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Entities;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public CreateReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository, IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _reservationRepository = reservationRepository;
            _cashTransactionRepository = cashTransactionRepository;
        }

        public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = new Domain.Entities.Reservation
            {
               PnrNo = request.PnrNo,
               DateOfJourney = request.DateOfJourney,
               TotalFare = request.TotalFare,
            };

            if (request.TotalFare < 0)
            {
                throw new Exception("TotalFare out of valid range");
            }



            Domain.Entities.CashTransaction cashTransaction = (await _cashTransactionRepository.GetAllAsync()).Where(c => c.DateOftransaction.Equals(reservation.DateOfJourney)).FirstOrDefault();
            if (cashTransaction == null)
            {
                var new_CashTransaction = new Domain.Entities.CashTransaction
                {
                    CashReceived = 0 + reservation.TotalFare,
                    CashRefunded = 0,
                    DateOftransaction = reservation.DateOfJourney,
                };
                Domain.Entities.CashTransaction cashTransaction_created = await _cashTransactionRepository.AddAsync(new_CashTransaction);
                reservation.CashTransactionID = cashTransaction_created.CashTransactionID;
            }
            else
            {
                cashTransaction.CashReceived += reservation.TotalFare;
                await _cashTransactionRepository.UpdateAsync(cashTransaction);
                reservation.CashTransactionID = cashTransaction.CashTransactionID;
            }


            await _reservationRepository.AddAsync(reservation);

            return reservation.ReservationID;
        }
    }
}
