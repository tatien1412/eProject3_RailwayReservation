using MediatR;
using RailwayTransaction.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayTransaction.Application.Commands.MasterManagement.RouteStation
{
    public class UpdateRouteStationCommand : IRequest
    {
        public int RouteStationID { get; set; } 
        public int TrainRouteID { get; set; }
        public int StationID { get; set; }
        public int Order { get; set; }  
    }
}
