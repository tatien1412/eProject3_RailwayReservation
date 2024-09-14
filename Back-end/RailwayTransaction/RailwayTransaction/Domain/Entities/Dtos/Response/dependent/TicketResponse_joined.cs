using System.ComponentModel.DataAnnotations;
namespace RailwayTransaction.Domain.Entities.Dtos.Response.dependent
{
    public class TicketResponse_joined
    {
        public int PnrNo { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int TotalPassengers { get; set; }

    }
}
