using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Features.CQRS.Results.CarResults;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Application.Interfaces.CarInterfaces;
using Udemy.CarBook.Domain.Entities;

namespace Udemy.CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandQueryHandler
    {
        private readonly ICarRepository carRepository;

        public GetCarWithBrandQueryHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }

        public async Task<List<GetCarWithBrandQueryResult>> Handle()
        {
            var value = await carRepository.GetCarsWithBrand();
            return value.Select(x => new GetCarWithBrandQueryResult
            {
                BigImageUrl = x.BigImageUrl,
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
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
