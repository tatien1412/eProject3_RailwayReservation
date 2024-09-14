using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TrainRouteMapper
    {
        public static TrainRouteResponse ConvertToResponse(TrainRoute trainRoute)
        {
            return new TrainRouteResponse
            {
                TrainRouteID = trainRoute.TrainRouteID,
                TrainRouteName  = trainRoute.TrainRouteName,
            };
        }
        public static TrainRouteResponse_joined ConvertToResponseAll(TrainRoute trainRoute,
                                                    List<RouteStation> routeStations)
        {
            return new TrainRouteResponse_joined
            {
                TrainRouteID = trainRoute.TrainRouteID,
                TrainRouteName = trainRoute.TrainRouteName,

                RouteStations = routeStations.Where(r => r.TrainRouteID == trainRoute.TrainRouteID).Select(r => RouteStationMapper.ConvertToResponse(r)).ToList(),


            };
        }
    }
}
