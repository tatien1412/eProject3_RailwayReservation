using RailwayTransaction.Domain.Entities.Dtos;
using RailwayTransaction.Domain.Entities.Dtos.Response;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class ReservationMapper
    {
        //public int ReservationID { get; set; }
        //public int PnrNo { get; set; }
        //public string UserID { get; set; }
        //public int TrainNo { get; set; }
        //public int ScheduleID { get; set; }
        //public int FromStationID { get; set; }
        //public int ToStationID { get; set; }
        //public string SeatNo { get; set; }
        //public DateTime DateOfJourney { get; set; }
        //public string CoachNo { get; set; }
        //public decimal Fare { get; set; }
        //public string CancellationStatus { get; set; }

        //// Navigation properties
        //public AppUser User { get; set; }
        //public Train Train { get; set; }
        //public Station FromStation { get; set; }
        //public Station ToStation { get; set; }
        //public Schedule Schedule { get; set; }
        //public Fare FareDetails { get; set; }
        //public ICollection<Ticket> Tickets { get; set; }

        public static ReservationResponse ConvertToResponse(Reservation reservation)
        {
            return new ReservationResponse
            {
                ReservationID = reservation.ReservationID,
                PnrNo = reservation.PnrNo,
                SeatNo = reservation.SeatNo,
                DateOfJourney = reservation.DateOfJourney,
                CoachNo = reservation.CoachNo,
                CancellationStatus = reservation.CancellationStatus
            };
        }
        public static Reservation ConvertToResponseAll(Reservation reservation,
                                                        AppUser appUser, 
                                                        Train train, 
                                                        Station fromStation, 
                                                        Station toStation, 
                                                        Schedule schedule, 
                                                        Fare fare, 
                                                        List<Ticket> tickets)
        {
            return new Reservation
            {
                ReservationID = reservation.ReservationID,
                PnrNo = reservation.PnrNo,
                SeatNo = reservation.SeatNo,
                DateOfJourney = reservation.DateOfJourney,
                CoachNo = reservation.CoachNo,
                CancellationStatus = reservation.CancellationStatus,

                User = appUser,
                Train = train,
                FromStation = fromStation,
                ToStation = toStation,
                Schedule = schedule,
                FareDetails = fare,
                Tickets = tickets

            };
        }

    }
}
