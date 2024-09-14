using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class CompartmentMapper
    {
        public static CompartmentResponse ConvertToResponse(Compartment compartment)
        {
            return new CompartmentResponse
            {
                CompartmentID = compartment.CompartmentID,
                TrainID = compartment.TrainID,
                CompartmentType = compartment.CompartmentType,
                NumberOfSeats = compartment.NumberOfSeats,
            };
        }

        public static CompartmentResponse_joined ConvertToResponseAll(Compartment compartment,
                                                    Train train,
                                                    List<Seat> seats)
        {
            return new CompartmentResponse_joined
            {
                CompartmentID = compartment.CompartmentID,
                TrainID = compartment.TrainID,
                CompartmentType = compartment.CompartmentType,
                NumberOfSeats = compartment.NumberOfSeats,

                Train = TrainMapper.ConvertToResponse(train),
                Seats = seats.Where(s => s.CompartmentID == compartment.CompartmentID).Select(s => SeatMapper.ConvertToResponse(s)).ToList(),

            };
        }
    }
}
