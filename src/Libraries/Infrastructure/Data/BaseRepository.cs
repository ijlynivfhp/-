using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Infrastructure.Data
{
    public class BaseRepository<TEntity> : BaseRepository<TEntity,int> where TEntity : BaseEntity  
    {
        public BaseRepository(IDbConnection connection, ISqlGenerator<TEntity> sqlGenerator)
        : base(connection, sqlGenerator)
        {
             

        }

    }
    public class BaseRepository<TEntity,TKey> : DapperRepository<TEntity>,IBaseRepository<TEntity,TKey> where TEntity : BaseEntity<TKey> where TKey : IEquatable<TKey>
    {
        public BaseRepository(IDbConnection connection, ISqlGenerator<TEntity> sqlGenerator)
        : base(connection, sqlGenerator)
        {


        }

    }
}
