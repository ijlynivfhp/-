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

        public virtual Task<bool> CreateAsync(string name, int CarBrandId)
        {
            var car = new Car();
            car.CarBrandId = CarBrandId;
            car.Name = name;
      
             
            return _carRepository.InsertAsync(car);
        }

        public virtual List<Car> GetAllList()
        {
            return _carRepository.FindAll().ToList();
        }

        public virtual new Car Get(int id)
        { 
            return _carRepository.FindById<CarBrand>(id, e=>e.CarBrand);
        }

		public virtual Task<IEnumerable<Car>> GetListByBrandName(string brandName)
		{
			var brand = _carBrandRepository.Find(x=>x.Name==brandName);
			return _carRepository.FindAllAsync<CarBrand>(x=>x.CarBrandId== brand.Id, e => e.CarBrand);
		}
	}
}
