using ApplicationCore.Interfaces; 
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Collections.Generic;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class CachedCarBrandService : CarBrandService, ICarBrandService
    { 
        private readonly ICarBrandRepository _carBrandRepository; 

        public CachedCarBrandService(  ICarBrandRepository  carBrandRepository ):base(carBrandRepository)
        {
           
            _carBrandRepository = carBrandRepository;
           
        }

       
    }
}
