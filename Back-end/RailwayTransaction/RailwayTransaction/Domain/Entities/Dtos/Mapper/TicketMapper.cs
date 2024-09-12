
using RailwayTransaction.Domain.Entities.Dtos.Response;
using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class TicketMapper
    {

        public static TicketResponse ConvertToResponse(Ticket ticket)
        {
            return new TicketResponse
            {
                Name = ticket.Name,
                Age = ticket.Age,
                Gender = ticket.Gender,
                TotalPassengers = ticket.TotalPassengers,
            };
        }
        //public static Ticket ConvertToResponseAll(Ticket ticket,
        //                                           Reservation reservations)
        //{
        //    return new Ticket
        //    {
        //        PnrNo = ticket.PnrNo,
        //        Name = ticket.Name,
        //        Age = ticket.Age,
        //        Gender = ticket.Gender,
        //        TotalPassengers = ticket.TotalPassengers,

        //        Reservation = reservations

        //    };
        //}
    }

}

