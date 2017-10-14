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
    public class CarRepository : BaseRepository<Car>, ICarRepository
    {
        public CarRepository(IDbConnection connection, ISqlGenerator<Car> sqlGenerator)
        : base(connection, sqlGenerator)
        {


        }

        public IReadOnlyList<Car> GetListByCarBrandName(string name)
        {
            var list = base.FindAll(x => x.CarBrand.BrandName.Contains(name));
            return list.ToList();
        }
    }
}
