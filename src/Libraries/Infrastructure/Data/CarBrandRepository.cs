using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MicroOrm.Dapper.Repositories;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Infrastructure.Data
{
    public class CarBrandRepository : BaseRepository<CarBrand,int>, ICarBrandRepository
    {
        public CarBrandRepository(IDbConnection connection, ISqlGenerator<CarBrand> sqlGenerator)
        : base(connection, sqlGenerator)
        {


        }

      
    }
}
