using ApplicationCore.Entities;
 
using MicroOrm.Dapper.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{

    public interface ICarBrandRepository : IBaseRepository<CarBrand,int>
    {
        // TODO: 自定义的接口方法  其实IDapperRepository 已经包含所有的数据库操作（crud）

    }
}
