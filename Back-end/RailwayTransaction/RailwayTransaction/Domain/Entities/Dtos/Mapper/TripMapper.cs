using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TripMapper
    {
        public static TripResponse ConvertToResponse(Trip trip)
        {
            return new TripResponse
            {
                TripID = trip.TripID,
                ReservationID = trip.ReservationID,
                ScheduleID = trip.ScheduleID,
                StartStationID = trip.StartStationID,
                EndStationID = trip.EndStationID,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime,
                TravelTime = trip.TravelTime,
            };
        }
        public static TripResponse_joined ConvertToResponseAll(Trip trip,
                                                    Reservation reservation,
                                                    Schedule schedule,
                                                    Station startStation,
                                                    Station endStation,
                                                    List<Reservation> reservations)
        {
            return new TripResponse_joined
            {
                TripID = trip.TripID,
                ReservationID = trip.ReservationID,
                ScheduleID = trip.ScheduleID,
                StartStationID = trip.StartStationID,
                EndStationID = trip.EndStationID,
                DepartureTime = trip.DepartureTime,
                ArrivalTime = trip.ArrivalTime,
                TravelTime = trip.TravelTime,

                Reservation = ReservationMapper.ConvertToResponse(reservation),
                Schedule = ScheduleMapper.ConvertToResponse(schedule),
                StartStation = StationMapper.ConvertToResponse(startStation),
                EndStation = StationMapper.ConvertToResponse(endStation),
                Reservations = reservations.Where(s => s.TripID == trip.TripID).Select(r => ReservationMapper.ConvertToResponse(r)).ToList(),

            };
        }
    }
}
