using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IBaseService<TEntity> : IBaseService<TEntity, int> where TEntity : BaseEntity
    {

    }
    public interface IBaseService<TEntity,TKey> where TEntity : BaseEntity<TKey> where TKey :IEquatable<TKey>
    {
        Task<bool> AddAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity, bool isLogicDelete = true);

        Task<bool> DeleteAsync(TKey id, bool isLogicDelete = true);

        Task<TEntity> GetAsync(TKey id);
         

        bool Add(TEntity entity);

        bool Update(TEntity entity);

        bool Delete(TEntity entity,bool isLogicDelete=true);

        bool Delete(TKey id, bool isLogicDelete = true);

        TEntity Get(TKey id);

        TEntity Find(Expression<Func<TEntity, bool>> predicate);

         
    }
}
