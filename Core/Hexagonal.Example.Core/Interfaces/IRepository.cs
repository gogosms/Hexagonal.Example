using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hexagonal.Example.Core.Models;

namespace Hexagonal.Example.Core.Interfaces
{
	public interface IRepository<T>  : IDisposable where T : class
	{
		Task<List<T>> GetAll();
		
		Task<T> Get(int id);
		
		Task<T> Add(T entity);
		
		Task<T> Update(T entity);
		
		Task<T> Delete(int id);

		Task<IEnumerable<T>> GetWhere(Expression<Func<T, bool>> predicate);
	}
}
