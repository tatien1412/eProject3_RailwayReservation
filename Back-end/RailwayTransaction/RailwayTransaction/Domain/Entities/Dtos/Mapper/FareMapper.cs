using RailwayTransaction.Domain.Entities.Dtos.Response;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public static class FareMapper
    {
        //public int FareID { get; set; }
        //public int ReservationID { get; set; }
        //public int Distance { get; set; }
        //public string CompartmentType { get; set; }
        //public string TrainType { get; set; }
        //public decimal Amount { get; set; }

        public static FareResponse ConvertToResponse(Fare fare)
        {
            return new FareResponse
            {
                FareID = fare.FareID,
                Distance = fare.Distance,
                CompartmentType = fare.CompartmentType,
                TrainType = fare.TrainType,
                Amount = fare.Amount
            };
        }
        public static Fare ConvertToResponseAll(Fare fare, Reservation reservation)
        {
            return new Fare
            {
                FareID = fare.FareID,
                Distance = fare.Distance,
                CompartmentType = fare.CompartmentType,
                TrainType = fare.TrainType,
                Amount = fare.Amount,

                Reservation =  reservation
            };
        }

    }
}
