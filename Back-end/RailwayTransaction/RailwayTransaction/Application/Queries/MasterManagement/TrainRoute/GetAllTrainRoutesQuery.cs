﻿using MediatR;


namespace RailwayTransaction.Application.Queries.MasterManagement.TrainRoute
{
    public class GetAllTrainRoutesQuery : IRequest<List<Domain.Entities.TrainRoute>>
    {
    }
}
