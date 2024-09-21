using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Reservation;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Repositories.MasterManagement;

namespace RailwayTransaction.Handler.MasterManagement.Reservation
{
    public class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand>
    {
        private readonly IRepository<Domain.Entities.Reservation, int> _reservationRepository;
        private readonly IRepository<Domain.Entities.CashTransaction, int> _cashTransactionRepository;

        public UpdateReservationCommandHandler(IRepository<Domain.Entities.Reservation, int> reservationRepository, IRepository<Domain.Entities.CashTransaction, int> cashTransactionRepository)
        {
            _reservationRepository = reservationRepository;
            _cashTransactionRepository = cashTransactionRepository;
        }

      


        public async Task<Unit> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationRepository.GetByIdAsync(request.ReservationID);

            if (reservation == null)
            {
                throw new Exception("Reservation not found");
            }

            reservation.PnrNo = request.PnrNo;
            reservation.DateOfJourney = request.DateOfJourney;
            reservation.TotalFare = request.TotalFare;

            await _reservationRepository.UpdateAsync(reservation);

            Domain.Entities.CashTransaction cashTransaction = (await _cashTransactionRepository.GetAllAsync()).Where(c => c.DateOftransaction.Equals(reservation.DateOfJourney)).FirstOrDefault();
            if (cashTransaction == null)
            {
                var new_CashTransaction = new Domain.Entities.CashTransaction
                {
                    CashReceived = (reservation.TotalFare < request.TotalFare) ?(request.TotalFare- reservation.TotalFare):0,
                    CashRefunded = (reservation.TotalFare > request.TotalFare) ? (reservation.TotalFare - request.TotalFare) : 0,
                    DateOftransaction = reservation.DateOfJourney,
                };
                await _cashTransactionRepository.AddAsync(new_CashTransaction);
            }
            else
            {
                if(reservation.TotalFare < request.TotalFare)
                {
                    
                    cashTransaction.CashReceived += request.TotalFare - reservation.TotalFare;
                    cashTransaction.CashRefunded = cashTransaction.CashRefunded;
                }
                else
                {
                    cashTransaction.CashReceived = cashTransaction.CashReceived;
                    cashTransaction.CashRefunded += reservation.TotalFare - request.TotalFare;
                }
                cashTransaction.DateOftransaction = reservation.DateOfJourney;
                await _cashTransactionRepository.UpdateAsync(cashTransaction);
            }
            return Unit.Value;
        }
    }
}
