﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Queries.BrandQueries;
using Udemy.CarBook.Application.Features.CQRS.Queries.CarQueries;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Features.CQRS.Results.CarResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var value = await repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {         
                BigImageUrl = value.BigImageUrl,
                BrandID = value.BrandID,
                CarID = value.CarID,
                CoverImageUrl = value.CoverImageUrl,
                Fuel = value.Fuel,
                Km = value.Km,
                Luggage = value.Luggage,
                Model = value.Model,
                Seat = value.Seat,
                Transmissions = value.Transmissions
            };
        }
    }
}
