using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.CarBook.Application.Interfaces;
using Udemy.CarBook.Persistance.Context;

namespace Udemy.CarBook.Persistance.Repository
{
	public class Repository<T> : IRepository<T> where T : class, new()
	{
		private readonly CarBookContext context;

		public Repository(CarBookContext context)
		{
			this.context = context;
		}

		public async Task CreateAsync(T entity)
		{
			context.Set<T>().Add(entity);
			await context.SaveChangesAsync();
		}

		public async Task DeleteAsync(T entity)
		{
			context.Set<T>().Remove(entity);
			await context.SaveChangesAsync();
		}

		public async Task<List<T>> GetAllAsync()
		{
			return await context.Set<T>().AsNoTracking().ToListAsync();
		}

		public async Task<T> GetByIdAsync(int id)
		{
			return await context.Set<T>().FindAsync(id);
		}

		public async Task UpdateAsync(T entity)
		{
			context.Set<T>().Update(entity);
			await context.SaveChangesAsync();
		}
	}
}
