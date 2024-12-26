using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Results.BrandResults;
using Udemy.CarBook.Application.Features.CQRS.Results.CarResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarQueryHandler
    {
        private readonly IRepository<Car> repository;

        public GetCarQueryHandler(IRepository<Car> repository)
        {
            this.repository = repository;
        }

        public async Task<List<GetCarQueryResult>> Handle()
        {
            var value = await repository.GetAllAsync();
            return value.Select(x => new GetCarQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmissions = x.Transmissions
            }).ToList();
        }
    }
}
