using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Entities.Dtos.Response;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ReservationMapper
    {
        public static ReservationResponse ConvertToResponse(Reservation reservation)
        {
            return new ReservationResponse
            {
                TripID = reservation.TripID,
                PnrNo = reservation.PnrNo,
                DateOfJourney = reservation.DateOfJourney,
                TotalFare = reservation.TotalFare,
            };
        }
        //public static Reservation ConvertToResponseAll(Reservation reservation,
        //                                                AppUser appUser, 
        //                                                Train train, 
        //                                                Station fromStation, 
        //                                                Station toStation, 
        //                                                Schedule schedule, 
        //                                                Fare fare, 
        //                                                List<Ticket> tickets)
        //{
        //    return new Reservation
        //    {
        //        ReservationID = reservation.ReservationID,
        //        PnrNo = reservation.PnrNo,
        //        SeatNo = reservation.SeatNo,
        //        DateOfJourney = reservation.DateOfJourney,
        //        CoachNo = reservation.CoachNo,
        //        CancellationStatus = reservation.CancellationStatus,

        //        User = appUser,
        //        Train = train,
        //        FromStation = fromStation,
        //        ToStation = toStation,
        //        Schedule = schedule,
        //        FareDetails = fare,
        //        Tickets = tickets

        //    };
        //}

    }
}
