using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Schedule
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public int TrainID { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }
        public string DateOfTravel { get; set; }

    }
}
