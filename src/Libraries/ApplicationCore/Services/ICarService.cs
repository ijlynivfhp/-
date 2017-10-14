
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ICarService : IBaseService<Car>
    {
        List<Car> GetAllList();

        Task CreateAsync(string name, int CarBrandId);
    }
}
