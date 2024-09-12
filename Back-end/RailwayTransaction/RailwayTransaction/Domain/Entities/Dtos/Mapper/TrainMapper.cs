using RailwayTransaction.Domain.Entities.Dtos.Response;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TrainMapper
    {
        public static TrainResponse ConvertToResponse(Train train)
        {
            return new TrainResponse
            {
                TrainName = train.TrainName,
                TrainRouteDetails = train.TrainRouteDetails,
                TrainRouteID = train.TrainRouteID,
                NumberOfCompartments = train.NumberOfCompartments,
            };
        }
        //public static Train ConvertToResponseAll(Train train,
        //                                            List<Schedule> schedules,
        //                                            List<Reservation> reservations)
        //{
        //    return new Train
        //    {
        //        TrainID = train.TrainID,
        //        TrainName = train.TrainName,
        //        Route = train.Route,
        //        NumberOfCompartments = train.NumberOfCompartments,

        //        Schedules = schedules,
        //        Reservations = reservations

        //    };
        //}
    }
}
