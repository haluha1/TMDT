using Infrastructure.Interfaces;
using Infrastructure.SharedKernel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.EF
{
	public class EFRepository<T, K> : IRepository<T, K>, IDisposable where T : DomainEntity<K>
	{
		private PhukienDTDbContext _context
		{
			get { return PhukienDTDbContext.Instance; }
		}
		
		public void Add(T entity)
		{
			_context.Set<T>().Add(entity);
		}

		public T AddReturn(T entity)
		{
			_context.Set<T>().Add(entity);
			_context.SaveChanges();
			return entity;
		}

		public void Dispose()
		{
			if (_context != null)
			{
				_context.Dispose();
			}
		}

		public virtual IQueryable<T> FindAll(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items;
		}

		public virtual IQueryable<T> FindAll(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate);
		}

		public IQueryable<T> FindAllNoTracking(params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.AsNoTracking();
		}

		public IQueryable<T> FindAllNoTracking(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			IQueryable<T> items = _context.Set<T>();
			if (includeProperties != null)
			{
				foreach (var includeProperty in includeProperties)
				{
					items = items.Include(includeProperty);
				}
			}
			return items.Where(predicate).AsNoTracking();
		}

		public T FindById(K id, params Expression<Func<T, object>>[] includeProperties)
		{

			return FindAll(includeProperties).SingleOrDefault(e => (object)e.KeyId == (object)id);
		}

		public T FindSingle(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
		{
			return FindAll(includeProperties).SingleOrDefault(predicate);
		}

		public void Remove(T entity)
		{
			_context.Set<T>().Remove(entity);
		}

		public void Remove(K id)
		{
			Remove(FindById(id));
		}

		public virtual void RemoveMultiple(List<T> entities)
		{
			_context.Set<T>().RemoveRange(entities);
		}

		public virtual void Update(T entity)
		{
			var entity2 = FindById(entity.KeyId);
			
			if (entity2 == null)
			{
				return;
			}
			_context.Entry(entity2).CurrentValues.SetValues(entity);
			_context.SaveChanges();
		}
	}
}
