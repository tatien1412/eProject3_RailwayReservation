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
                TrainRouteDetails = train.TrainRouteDetails,
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
                TrainRouteDetails = train.TrainRouteDetails,
                TrainRouteID = train.TrainRouteID,
                NumberOfCompartments = train.NumberOfCompartments,

                TrainRoute = TrainRouteMapper.ConvertToResponse(trainRoute),
                Compartments = compartments.Where(c => c.TrainID == train.TrainID).Select(c => CompartmentMapper.ConvertToResponse(c)).ToList(),
                Schedules = schedules.Where(s => s.TrainID == train.TrainID).Select(s => ScheduleMapper.ConvertToResponse(s)).ToList(),

            };
        }
    }
}
