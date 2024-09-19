using RailwayTransaction.Domain.Entities.Dtos.Response.dependent;
using RailwayTransaction.Domain.Entities.Dtos.Response.independent;
using System.Diagnostics;

namespace RailwayTransaction.Domain.Entities.Dtos.Mapper
{
    public class CashTransactionMapper
    {
        public static CashTransactionResponse ConvertToResponse(CashTransaction cashTransaction)
        {
            return new CashTransactionResponse
            {
                CashTransactionID = cashTransaction.CashTransactionID,
                CashReceived = cashTransaction.CashReceived,
                CashRefunded = cashTransaction.CashRefunded,
                DateOftransaction = cashTransaction.DateOftransaction,
            };
        }
        //public static CashTransactionResponse_joined ConvertToResponseAll(CashTransaction cashTransaction,
        //                                            List<Reservation> reservations)
        //{
        //    return new CashTransactionResponse_joined
        //    {
        //        CashTransactionID = cashTransaction.CashTransactionID,
        //        CashReceived = cashTransaction.CashReceived,
        //        CashRefunded = cashTransaction.CashRefunded,
        //        DateOftransaction = cashTransaction.DateOftransaction,

        //        Reservations = reservations.Where(r => r.CompartmentID == compartment.CompartmentID).Select(s => SeatMapper.ConvertToResponse(s)).ToList(),

        //    };
        //}
    }
}
