using System.ComponentModel.DataAnnotations;
namespace RailwayTransaction.Domain.Entities.Dtos.Response
{
    public class TicketResponse
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public char Gender { get; set; }
        public int TotalPassengers { get; set; }
    }
}
