using MediatR;

namespace RailwayTransaction.Application.Commands.MasterManagement.Schedule
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public int TrainNo { get; set; }
        public int StartStationID { get; set; }
        public int EndStationID { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public string DayOfWeek { get; set; }
    }
}
