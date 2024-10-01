using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TrainMapper
    {
        public static TrainResponse ConvertToResponse(Train train)
        {
            return new TrainResponse
            {
                TrainID = train.TrainID,
                TrainName = train.TrainName,
                TrainStatus = train.TrainStatus,
                TrainRouteID = train.TrainRouteID,
                NumberOfCompartments = train.NumberOfCompartments,
            };
        }
        public static TrainResponse_joined ConvertToResponseAll(Train train,
                                                    TrainRoute trainRoute,
                                                    List<Compartment> compartments,
                                                    List<Schedule> schedules)
        {
            return new TrainResponse_joined
            {
                TrainID = train.TrainID,
                TrainName = train.TrainName,
                TrainStatus = train.TrainStatus,
                TrainRouteID = train.TrainRouteID,
                NumberOfCompartments = train.NumberOfCompartments,

                TrainRoute = TrainRouteMapper.ConvertToResponse(trainRoute),
                Compartments = compartments.Where(c => c.TrainID == train.TrainID).Select(c => CompartmentMapper.ConvertToResponse(c)).ToList(),
                Schedules = schedules.Where(s => s.TrainID == train.TrainID).Select(s => ScheduleMapper.ConvertToResponse(s)).ToList(),

            };
        }
        public static TrainSearchReponse_joined ConvertToResponseSearch(Train train,
                                                    TrainRoute trainRoute,
                                                    List<Compartment> compartments,
                                                    List<Schedule> schedules,
                                                    List<RouteStation> routeStations)
        {
            return new TrainSearchReponse_joined
            {
                TrainID = train.TrainID,
                TrainName = train.TrainName,
                TrainStatus = train.TrainStatus,
                TrainRouteID = train.TrainRouteID,
                NumberOfCompartments = train.NumberOfCompartments,

                TrainRoute = TrainRouteMapper.ConvertToResponse(trainRoute),
                Compartments = compartments.Where(c => c.TrainID == train.TrainID).Select(c => CompartmentMapper.ConvertToResponse(c)).ToList(),
                Schedules = schedules.Where(s => s.TrainID == train.TrainID).Select(s => ScheduleMapper.ConvertToResponse(s)).ToList(),
                RouteStations = routeStations.Where(r => r.TrainRouteID == train.TrainRouteID).Select(r => RouteStationMapper.ConvertToResponse(r)).ToList(),
            };
        }
    }
}