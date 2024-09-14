using System.ComponentModel.DataAnnotations;

namespace RailwayTransaction.Domain.Entities.Dtos.Response.independent
{
    public class StationResponse
    {
        public int StationID { get; set; }
        public string StationCode { get; set; }
        public string StationName { get; set; }
        public string RailwayDivisionName { get; set; }

    }
}
