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
                SeatType= compartment.SeatType,
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

                SeatType = compartment.SeatType,
                Train = TrainMapper.ConvertToResponse(train),
                Seats = seats.Where(s => s.CompartmentID == compartment.CompartmentID).Select(s => SeatMapper.ConvertToResponse(s)).ToList(),

            };
        }
        public static AvailableSeat_joined ConvertToAvailableseatResponse(int compartmentid,
                                                    List<Seat> seats)
        {
            return new AvailableSeat_joined
            {
                
                Seats = seats.Where(s => s.CompartmentID == compartmentid).Select(s => SeatMapper.ConvertToResponse(s)).ToList(),

            };
        }
    }
}
