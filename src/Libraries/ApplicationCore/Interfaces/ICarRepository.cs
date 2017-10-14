using ApplicationCore.Entities;
 
using MicroOrm.Dapper.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{

    public interface ICarRepository : IBaseRepository<Car,int>
    {
        // TODO: 自定义的接口方法  其实IDapperRepository 已经包含所有的数据库操作（crud）


        /// <summary>
        /// 根据品牌名字获取所有汽车
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IReadOnlyList<Car> GetListByCarBrandName(string name);
    }
}
