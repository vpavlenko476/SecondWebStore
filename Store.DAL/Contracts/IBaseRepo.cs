using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Contracts
{
	interface IBaseRepo<T>: IDisposable
	{
		Task<int> Add(T item);
		Task<int> AddRange(IList<T> entites);
		Task<int> Update(T entite);
		Task<int> Delete(T entity);
		Task<T> GetOne(int? Id);
		IQueryable<T> GetSome(Expression<Func<T, bool>> where);
		IQueryable<T> GetAll();
	}
}
