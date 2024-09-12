using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ReservationMapper
    {
        public static ReservationResponse ConvertToResponse(Reservation reservation)
        {
            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                TripID = reservation.TripID,
                PnrNo = reservation.PnrNo,
                DateOfJourney = reservation.DateOfJourney,
                TotalFare = reservation.TotalFare,
            };
        }
        public static ReservationResponse_joined ConvertToResponseAll(Reservation reservation,
                                                        Trip trip,
                                                        Ticket ticket,
                                                        List<Seat> seats)
        {
            return new ReservationResponse_joined
            {
                ReservationID = reservation.ReservationID,
                TripID = reservation.TripID,
                PnrNo = reservation.PnrNo,
                DateOfJourney = reservation.DateOfJourney,
                TotalFare = reservation.TotalFare,

                Trip = TripMapper.ConvertToResponse(trip),
                Ticket = TicketMapper.ConvertToResponse(ticket),
                Seats = seats.Where(s => s.ReservationID == reservation.ReservationID).Select(s => SeatMapper.ConvertToResponse(s)).ToList(),
            };
        }

    }
}
