using Microsoft.EntityFrameworkCore;
using Udemy.CarBook.Application.Interfaces.CarInterfaces;
using Udemy.CarBook.Domain.Entities;
using Udemy.CarBook.Persistance.Context;

namespace Udemy.CarBook.Persistance.Repository.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarBookContext context;

        public CarRepository(CarBookContext context)
        {
            this.context = context;
        }

        public async Task<List<Car>> GetCarsWithBrand()
        {
            var values = await context.Set<Car>().Include(x=> x.Brand).ToListAsync();
            return values;
        }

        public async Task<List<Car>> GetLast5WithBrands()
        {
            
            var values = await context.Set<Car>().Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToListAsync();
            return values;
        }
    }
}
