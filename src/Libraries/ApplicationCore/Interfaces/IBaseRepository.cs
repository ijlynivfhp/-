using ApplicationCore.Entities;
using MicroOrm.Dapper.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Interfaces
{
    public interface IBaseRepository<TEntity> : IBaseRepository<TEntity,int> where TEntity : BaseEntity 
    {
    }
    public interface IBaseRepository<TEntity, TKey> : IDapperRepository<TEntity> where TEntity : BaseEntity<TKey> where TKey:IEquatable<TKey>
    {
    }
}
