using ApplicationCore.Entities;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using ApplicationCore;

namespace Infrastructure.Services
{
	public class BaseService<TEntity> : BaseService<TEntity, int> where TEntity : BaseEntity
	{
		public BaseService(IBaseRepository<TEntity, int> repo) : base(repo)
		{ }
	}
	public class BaseService<TEntity, TKey> : IBaseService<TEntity, TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
	{
		private readonly IBaseRepository<TEntity, TKey> _repo;
		 

		public BaseService(IBaseRepository<TEntity, TKey> repo)
		{
			_repo = repo;
		}
		public bool Add(TEntity entity)
		{
			return _repo.Insert(entity);
		}

		public Task<bool> AddAsync(TEntity entity)
		{
			return _repo.InsertAsync(entity);
		}

		public bool Delete(TEntity entity, bool isLogicDelete = true)
		{
			if (isLogicDelete)
			{

				return Update(entity);
			}
			else
			{
				return _repo.Delete(entity);
			}

		}

		public bool Delete(TKey id, bool isLogicDelete = true)
		{

			if (isLogicDelete)
			{
				var entity = Find(x => x.Id.Equals(id));
				return Update(entity);
			}
			else
			{
				return _repo.Delete(x => x.Id.Equals(id));
			}
		}

		public Task<bool> DeleteAsync(TEntity entity, bool isLogicDelete = true)
		{
			throw new NotImplementedException();
		}

		public Task<bool> DeleteAsync(TKey id, bool isLogicDelete = true)
		{
			throw new NotImplementedException();
		}

		public virtual TEntity Find(Expression<Func<TEntity, bool>> predicate)
		{
			return _repo.Find(predicate
				);
		}

		public virtual Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> predicate)
		{
			return _repo.FindAsync(predicate
				);
		}

		public virtual QueryPageParameter FindWithPages(Expression<Func<TEntity, bool>> predicate, Func<TEntity, object> order,   QueryPageParameter queryPage)
		{ 
			queryPage.SetTotalNumber(_repo.FindAll(predicate).Count());
			queryPage.SetResult(_repo.FindAll(predicate).OrderBy(s=>s.Id).Skip((queryPage.PageIndex - 1) * queryPage.PageSize).Take(queryPage.PageSize));
			return queryPage;
		}

		public async virtual Task<QueryPageParameter> FindWithPagesAsync(Expression<Func<TEntity, bool>> predicate, Func<TEntity, object> order,   QueryPageParameter queryPage)
		{
			var datas = await _repo.FindAllAsync(predicate); 
			queryPage.SetTotalNumber(datas.Count()); 
			queryPage.SetResult(datas.OrderBy(s => s.Id).Skip((queryPage.PageIndex - 1) * queryPage.PageSize).Take(queryPage.PageSize));
			return queryPage; 
		}

		public  virtual TEntity Get(TKey id)
		{

			var s = _repo.SqlGenerator.GetSelectById(id);
			var sql = s.GetSql();
			var p = s.Param;

			return _repo.FindById(id);
		}

		public virtual Task<TEntity> GetAsync(TKey id)
		{
			return _repo.FindByIdAsync(id);
		}

		public bool Update(TEntity entity)
		{
			return _repo.Update(entity);
		}

		public Task<bool> UpdateAsync(TEntity entity)
		{
			return _repo.UpdateAsync(entity);
		}
	}
}
