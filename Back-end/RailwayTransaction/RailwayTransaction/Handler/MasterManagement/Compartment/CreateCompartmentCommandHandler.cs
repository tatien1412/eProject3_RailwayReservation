using MediatR;
using RailwayTransaction.Application.Commands.MasterManagement.Compartment;
using RailwayTransaction.Domain.Interface;
using RailwayTransaction.Domain.Entities; // Import để sử dụng các thực thể
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RailwayTransaction.Handler.MasterManagement.Compartment
{
    public class CreateCompartmentCommandHandler : IRequestHandler<CreateCompartmentCommand, int>
    {
        private readonly IRepository<Domain.Entities.Compartment, int> _compartmentRepository;
        private readonly IRepository<Domain.Entities.Seat, int> _seatRepository; // Repository cho Seat

        public CreateCompartmentCommandHandler(IRepository<Domain.Entities.Compartment, int> compartmentRepository, IRepository<Domain.Entities.Seat, int> seatRepository)
        {
            _compartmentRepository = compartmentRepository;
            _seatRepository = seatRepository; // Inject Seat repository
        }

        public async Task<int> Handle(CreateCompartmentCommand request, CancellationToken cancellationToken)
        {
            var compartment = new Domain.Entities.Compartment
            {
                TrainID = request.TrainID,
                CompartmentType = request.CompartmentType,
                SeatType = request.SeatType,  // Loại ghế được thêm từ request
                NumberOfSeats = request.NumberOfSeats,
            };

            // Thêm khoang vào cơ sở dữ liệu
            await _compartmentRepository.AddAsync(compartment);

            // Tạo 50 ghế tự động sau khi khoang được thêm
            var seats = Enumerable.Range(1, compartment.NumberOfSeats).Select(i => new Domain.Entities.Seat
            {
                CompartmentID = compartment.CompartmentID,
                SeatNumber = i.ToString(),
                SeatStatus = "Available",
                ReservationID = null,  // Ghế chưa có đặt chỗ, nên để null
                Fare = CalculateFare(compartment.CompartmentType, compartment.SeatType)
            }).ToList();



            await _seatRepository.AddRangeAsync(seats);


            return compartment.CompartmentID;
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
