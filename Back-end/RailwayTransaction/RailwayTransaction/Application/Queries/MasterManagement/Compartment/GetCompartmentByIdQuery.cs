﻿using MediatR;

namespace RailwayTransaction.Application.Queries.MasterManagement.Compartment
{
    public class GetCompartmentByIdQuery : IRequest<Domain.Entities.Dtos.Response.dependent.CompartmentResponse_joined>
    {
        public int CompartmentID { get; set; }

        public GetCompartmentByIdQuery(int compartmentID)
        {
            CompartmentID = compartmentID;
        }
    }
}
