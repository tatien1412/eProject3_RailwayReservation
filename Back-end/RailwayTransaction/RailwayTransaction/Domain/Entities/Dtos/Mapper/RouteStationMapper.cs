using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class RouteStationMapper
    {
        public static RouteStationResponse ConvertToResponse(RouteStation routeStation)
        {
            return new RouteStationResponse
            {
                RouteStationID = routeStation.RouteStationID,
                TrainRouteID = routeStation.TrainRouteID,
                StationID = routeStation.StationID,
                OrderInRoute = routeStation.OrderInRoute,
            };
        }
        public static RouteStationResponse_joined ConvertToResponseAll(RouteStation routeStation,
                                                    TrainRoute trainRoute,
                                                    Station station)
        {
            return new RouteStationResponse_joined
            {
                RouteStationID = routeStation.RouteStationID,
                TrainRouteID = routeStation.TrainRouteID,
                StationID = routeStation.StationID,
                OrderInRoute = routeStation.OrderInRoute,

                TrainRoute = TrainRouteMapper.ConvertToResponse(trainRoute),
                Station = StationMapper.ConvertToResponse(station),

            };
        }
    }
}
