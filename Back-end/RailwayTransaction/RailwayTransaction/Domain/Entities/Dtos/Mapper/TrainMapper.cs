using RailwayTransaction.Domain.Entities.Dtos.Response;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TrainMapper
    {
        //public int TrainID { get; set; }
        //public string TrainName { get; set; }
        //public string Route { get; set; }
        //public int NumberOfCompartments { get; set; }

        //// Navigation properties
        //public ICollection<Schedule> Schedules { get; set; }
        //public ICollection<Reservation> Reservations { get; set; }

        public static TrainResponse ConvertToResponse(Train train)
        {
            return new TrainResponse
            {
                TrainID = train.TrainID,
                TrainName = train.TrainName,
                Route = train.Route,
                NumberOfCompartments = train.NumberOfCompartments

            };
        }
        public static Train ConvertToResponseAll(Train train,
                                                    List<Schedule> schedules,
                                                    List<Reservation> reservations)
        {
            return new Train
            {
                TrainID = train.TrainID,
                TrainName = train.TrainName,
                Route = train.Route,
                NumberOfCompartments = train.NumberOfCompartments,

                Schedules = schedules,
                Reservations = reservations

            };
        }
    }
}
