using RailwayTransaction.Domain.Entities.Dtos.Response;
using static System.Collections.Specialized.BitVector32;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class StationMapper
    {

        public static StationResponse ConvertToResponse(Station station)
        {
            return new StationResponse
            {
                StationCode = station.StationCode,
                StationName = station.StationName,
                RailwayDivisionName = station.RailwayDivisionName,
            };
        }
        //public static Station ConvertToResponseAll(Station station,
        //                                           List<Reservation> fromReservations,
        //                                           List<Reservation> toReservations)
        //{
        //    return new Station
        //    {
        //        StationID = station.StationID,
        //        StationCode = station.StationCode,
        //        StationName = station.StationName,
        //        RailwayDivisionName = station.RailwayDivisionName,

        //        FromReservations = fromReservations,
        //        ToReservations = toReservations

        //    };
        //}
    }
}
