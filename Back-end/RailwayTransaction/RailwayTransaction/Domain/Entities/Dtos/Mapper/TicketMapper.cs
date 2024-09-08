
using RailwayTransaction.Domain.Entities.Dtos.Response;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TicketMapper
    {
        //[Key]
        //public int PnrNo { get; set; }
        //public string Name { get; set; }
        //public int Age { get; set; }
        //public char Gender { get; set; }
        //public int TotalPassengers { get; set; }

        //// Foreign key
        //public int ReservationID { get; set; }
        //public Reservation Reservation { get; set; }

        public static TicketResponse ConvertToResponse(Ticket ticket)
        {
            return new TicketResponse
            {
                PnrNo = ticket.PnrNo,
                Name = ticket.Name,
                Age = ticket.Age,
                Gender = ticket.Gender,
                TotalPassengers = ticket.TotalPassengers
                
            };
        }
        public static Ticket ConvertToResponseAll(Ticket ticket,
                                                   Reservation reservations)
        {
            return new Ticket
            {
                PnrNo = ticket.PnrNo,
                Name = ticket.Name,
                Age = ticket.Age,
                Gender = ticket.Gender,
                TotalPassengers = ticket.TotalPassengers,

                Reservation = reservations

            };
        }
    }

}

