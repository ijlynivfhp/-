using ApplicationCore.Interfaces; 
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Collections.Generic;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class CarBrandService :BaseService<CarBrand>, ICarBrandService
    { 
        private readonly ICarBrandRepository _carBrandRepository; 

        public CarBrandService(  ICarBrandRepository  carBrandRepository ):base(carBrandRepository)
        {
           
            _carBrandRepository = carBrandRepository;
           
        }

        public Task CreateAsync(string name)
        {
            var carBrand = new CarBrand {   };
             
            return _carBrandRepository.InsertAsync(carBrand);
        }
    }
}
