
using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
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
                PnrNo = ticket.PnrNo,
                Name = ticket.Name,
                Age = ticket.Age,
                Gender = ticket.Gender,
                TotalPassengers = ticket.TotalPassengers,
            };
        }
        public static TicketResponse_joined ConvertToResponseAll(Ticket ticket)
        {
            return new TicketResponse_joined
            {
                PnrNo = ticket.PnrNo,
                Name = ticket.Name,
                Age = ticket.Age,
                Gender = ticket.Gender,
                TotalPassengers = ticket.TotalPassengers,

            };
        }
    }

}

