﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Queries.StatisticQueries;
using UdemyCarBook.Application.Features.Mediator.Results.StatisticResults;
using UdemyCarBook.Application.Interfaces.StatisticInteraces;

namespace UdemyCarBook.Application.Features.Mediator.Handlers.StatisticHandlers
{
    public class GetAvgRentForWeeklyQueryHandler : IRequestHandler<GetAvgRentForWeeklyQuery, GetAvPriceForWeeklyQueryResult>
    {
        private readonly IStatisticRepository _statisticRepository;

        public GetAvgRentForWeeklyQueryHandler(IStatisticRepository statisticRepository)
        {
            _statisticRepository = statisticRepository;
        }

        public async Task<GetAvPriceForWeeklyQueryResult> Handle(GetAvgRentForWeeklyQuery request, CancellationToken cancellationToken)
        {
            return new GetAvPriceForWeeklyQueryResult
            {
                AvPriceForWeekly = await _statisticRepository.GetAvgRentForWeeklyAsync()
            };
        }
    }
}