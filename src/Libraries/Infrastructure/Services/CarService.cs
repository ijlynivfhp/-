using ApplicationCore.Interfaces; 
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class CarService :BaseService<Car>, ICarService
    {
        private readonly ICarRepository _carRepository;
        private readonly ICarBrandRepository _carBrandRepository; 

        public CarService(ICarRepository  carRepository, ICarBrandRepository  carBrandRepository ):base(carRepository)
        {
            _carRepository = carRepository;
            _carBrandRepository = carBrandRepository;
           
        }

        public Task CreateAsync(string name, int CarBrandId)
        {
            var car = new Car();
            car.CarBrandId = CarBrandId;
            car.Name = name;
      
             
            return _carRepository.InsertAsync(car);
        }

        public List<Car> GetAllList()
        {
            return _carRepository.FindAll().ToList();
        }

        public new Car Get(int id)
        { 
            return _carRepository.FindById<CarBrand>(id, e=>e.CarBrand);
        }

    }
}
