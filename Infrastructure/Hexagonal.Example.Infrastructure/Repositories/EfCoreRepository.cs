using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hexagonal.Example.Core.Interfaces;
using Hexagonal.Example.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Hexagonal.Example.Infrastructure.Repositories
{
	public class EfCoreRepository<TEntity> : IRepository<TEntity>
		where TEntity : EntityBase
		
	{
		private readonly AppDbContext _context;

		public EfCoreRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<TEntity> Add(TEntity entity)
		{
			await _context.Set<TEntity>().AddAsync(entity);
			await _context.SaveChangesAsync();
			return entity;
		}

		public async Task<TEntity> Delete(int id)
		{
			var entity = await _context.Set<TEntity>().FindAsync(id);
			if (entity == null)
			{
				return null;
			}

			_context.Set<TEntity>().Remove(entity);
			await _context.SaveChangesAsync();

			return entity;
		}

		public async Task<IEnumerable<TEntity>> GetWhere(Expression<Func<TEntity, bool>> predicate) 
			=> await _context.Set<TEntity>().Where(predicate).ToListAsync();

		public async Task<TEntity> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

		public async Task<List<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

		public async Task<TEntity> Update(TEntity entity)
		{
			_context.Entry(entity).State = EntityState.Modified;
			await _context.SaveChangesAsync();
			return entity;
		}

		private bool _disposed = false;
		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_context.Dispose();
				}
			}
			_disposed = true;
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
	}
}