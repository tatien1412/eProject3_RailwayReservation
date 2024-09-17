using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class SeatMapper
    {
        public static SeatResponse ConvertToResponse(Seat seat)
        {
            return new SeatResponse
            {
                SeatID = seat.SeatID,
                CompartmentID = seat.CompartmentID,
                SeatNumber = seat.SeatNumber,
                SeatStatus = seat.SeatStatus,
                Fare = seat.Fare,
                ReservationID = seat.ReservationID,
            };
        }
        public static SeatResponse_joined ConvertToResponseAll(Seat seat,
                                                    Compartment compartment,
                                                    Reservation reservation)
        {
            return new SeatResponse_joined
            {
                SeatID = seat.SeatID,
                CompartmentID = seat.CompartmentID,
                SeatNumber = seat.SeatNumber,
                SeatStatus = seat.SeatStatus,
                Fare = seat.Fare,
                ReservationID = seat.ReservationID,

                Compartment = CompartmentMapper.ConvertToResponse(compartment),
                Reservation = ReservationMapper.ConvertToResponse(reservation),

            };
        }
    }
}
