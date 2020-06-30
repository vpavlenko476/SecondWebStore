using Microsoft.EntityFrameworkCore;
using Store.DAL.Context;
using Store.DAL.Contracts;
using Store.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Store.DAL.Repositories
{
	public class BaseRepo<T>: IBaseRepo<T> 
		where T : BaseEntity
	{
		private StoreContext _db { get; }
		private readonly DbSet<T> _table;
		protected StoreContext Context => _db;
		public BaseRepo(StoreContext context)
		{
			if (context == null) throw new ArgumentNullException("Null DbContext");
			_db = context;
			_table = _db.Set<T>();
		}
		public async Task<int> Add(T entity)
		{
			await _table.AddAsync(entity);
			return _db.SaveChanges();
		}

		public async Task<int> AddRange(IList<T> entites)
		{
			await _table.AddRangeAsync(entites);
			return _db.SaveChanges();
		}

		public async Task<int> Delete(T entity)
		{
			var _entity = await _table.FindAsync(entity.Id);
			_db.Entry(_entity).State = EntityState.Deleted;
			return _db.SaveChanges();
		}

		public IQueryable<T> GetAll()
		{
			return _table;
		}

		public async Task<T> GetOne(int? Id)
		{
			return await _table.FindAsync(Id);
		}

		public async Task<int> Update(T entity)
		{
			var _entity = await _table.FindAsync(entity.Id);
			await Task.Run(() => _db.Entry(_entity).CurrentValues.SetValues(entity));
			return _db.SaveChanges();
		}

		public IQueryable<T> GetSome(Expression<Func<T, bool>> where)
		{
			return _table.Where(where);
		}
		public void Dispose()
		{
			_db?.Dispose();
		}
	}
}
