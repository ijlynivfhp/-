
using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface ICarBrandService : IBaseService<CarBrand>
    {
        Task CreateAsync(string name);
    }
}
