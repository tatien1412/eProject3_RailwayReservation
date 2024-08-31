using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Station
{
    public class GetStationByIdQuery : IRequest<Domain.Entities.Station>
    {
        public int StationID { get; set; }

        public GetStationByIdQuery(int stationID)
        {
            StationID = stationID;
        }
    }
}
