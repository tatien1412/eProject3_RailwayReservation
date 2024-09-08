using RailwayTransaction.Domain.Entities.Dtos.Response;
using static System.Collections.Specialized.BitVector32;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class StationMapper
    {
        //public int StationID { get; set; }
        //public string StationCode { get; set; }
        //public string StationName { get; set; }
        //public string RailwayDivisionName { get; set; }

        //// Navigation properties
        //public ICollection<Reservation> FromReservations { get; set; }
        //public ICollection<Reservation> ToReservations { get; set; }

        public static StationResponse ConvertToResponse(Station station)
        {
            return new StationResponse
            {
                StationID = station.StationID,
                StationCode = station.StationCode,
                StationName = station.StationName,
                RailwayDivisionName = station.RailwayDivisionName
            };
        }
        public static Station ConvertToResponseAll(Station station,
                                                   List<Reservation> fromReservations,
                                                   List<Reservation> toReservations)
        {
            return new Station
            {
                StationID = station.StationID,
                StationCode = station.StationCode,
                StationName = station.StationName,
                RailwayDivisionName = station.RailwayDivisionName,

                FromReservations = fromReservations,
                ToReservations = toReservations

            };
        }
    }
}
