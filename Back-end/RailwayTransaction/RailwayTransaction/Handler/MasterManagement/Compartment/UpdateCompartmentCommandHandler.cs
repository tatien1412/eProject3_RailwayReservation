using MediatR;
using Microsoft.EntityFrameworkCore;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class UpdateCompartmentCommandHandler : IRequestHandler<UpdateCompartmentCommand>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository;

        public UpdateCompartmentCommandHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository,
                                               IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _compartmentRepository = compartmentRepository;
            _seatRepository = seatRepository;
        }

        public async Task<Unit> Handle(UpdateCompartmentCommand request, CancellationToken cancellationToken)
        {
            // Tìm khoang tàu theo ID
            var compartment = await _compartmentRepository.GetByIdAsync(request.CompartmentID);

            if (compartment == null)
            {
                throw new Exception("Compartment not found");
            }

            // Cập nhật thông tin khoang tàu
            compartment.TrainID = request.TrainID;
            compartment.CompartmentType = request.CompartmentType;
            compartment.NumberOfSeats = request.NumberOfSeats;

            if (request.NumberOfSeats <= 0 || request.NumberOfSeats > 50)
            {
                throw new Exception("NumberOfSeats out of valid range");
            }

            // Lấy danh sách ghế hiện tại của khoang
            var currentSeats = await _seatRepository.GetAllAsyncWithPredicate(s => s.CompartmentID == compartment.CompartmentID);
            int currentSeatCount = currentSeats.Count();

            if (request.NumberOfSeats > currentSeatCount)
            {
                // Nếu số ghế mới lớn hơn, thêm ghế
                var seatsToAdd = Enumerable.Range(currentSeatCount + 1, request.NumberOfSeats - currentSeatCount)
                                           .Select(i => new Domain.Entities.Seat
                                           {
                                               CompartmentID = compartment.CompartmentID,
                                               SeatNumber = i.ToString(),
                                               SeatStatus = "Available",
                                               ReservationID = null,  // Ghế chưa có đặt chỗ, nên để null
                                               Fare = CalculateFare(compartment.CompartmentType, compartment.SeatType)
                                           }).ToList();

                await _seatRepository.AddRangeAsync(seatsToAdd);
            }
            else if (request.NumberOfSeats < currentSeatCount)
            {
                // Nếu số ghế mới nhỏ hơn, xóa bớt ghế
                var seatsToRemove = currentSeats
                                    .OrderByDescending(s => s.SeatNumber) // Sắp xếp ghế theo thứ tự giảm dần
                                    .Take(currentSeatCount - request.NumberOfSeats); // Lấy số ghế dư thừa

                await _seatRepository.RemoveRangeAsync(seatsToRemove);
            }

            // Cập nhật lại khoang tàu trong cơ sở dữ liệu
            await _compartmentRepository.UpdateAsync(compartment);

            return Unit.Value;
        }

        // Hàm tính giá vé
        private decimal CalculateFare(string compartmentType, string seatType)
        {
            decimal baseFare = 100;  // Giá cơ bản

            switch (compartmentType)
            {
                case "AC1":
                    baseFare += 200;
                    break;
                case "AC2":
                    baseFare += 100;
                    break;
                case "AC3":
                    baseFare += 50;
                    break;
                default:
                    baseFare += 0;
                    break;
            }

            if (seatType == "Sleep")
            {
                baseFare += 50;  // Tăng giá cho ghế ngủ
            }

            return baseFare;
        }
    }
}
