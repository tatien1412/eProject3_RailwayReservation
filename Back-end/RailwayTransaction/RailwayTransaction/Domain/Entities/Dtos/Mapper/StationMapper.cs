using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using static System.Collections.Specialized.BitVector32;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class StationMapper
    {

        public static StationResponse ConvertToResponse(Station station)
        {
            return new StationResponse
            {
                StationID = station.StationID,
                StationCode = station.StationCode,
                StationName = station.StationName,
                RailwayDivisionName = station.RailwayDivisionName,
            };
        }
        public static StationResponse_joined ConvertToResponseAll(Station station,
                                                   List<RouteStation> routeStations)
        {
            return new StationResponse_joined
            {
                StationID = station.StationID,
                StationCode = station.StationCode,
                StationName = station.StationName,
                RailwayDivisionName = station.RailwayDivisionName,

                RouteStations = routeStations.Where(r => r.StationID == station.StationID).Select(r => RouteStationMapper.ConvertToResponse(r)).ToList(),

            };
        }
    }
}
