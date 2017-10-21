using ApplicationCore.Interfaces;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using ApplicationCore.Services;
using System;
using Microsoft.Extensions.Caching.Memory;
using ApplicationCore;

namespace Infrastructure.Services
{
    public class CachedCarService : CarService, ICarService
    {
		public ICarService _carService;
		public ICarBrandService  _carBrandService;
		private readonly IMemoryCache _cache;
		private readonly ICarRepository _carRepository;
		private readonly ICarBrandRepository _carBrandRepository;

		private static readonly string _key = "car";
		/// <summary>
		/// pages-{0}-{1}-{2}-{3}
		/// </summary>
		private static readonly string _pagesKeyTemplate = "pages-{0}-{1}-{2}-{3}";
		private static readonly TimeSpan _defaultCacheDuration = TimeSpan.FromSeconds(30);

		public CachedCarService(IMemoryCache cache, ICarRepository carRepository, ICarBrandRepository carBrandRepository):base(carRepository, carBrandRepository)
        {
			_cache = cache;
			_carRepository = carRepository;
			_carBrandRepository = carBrandRepository;

		}


		public override Car Find(Expression<Func<Car, bool>> predicate)
		{
			 
			return base.Find(predicate);
		}
	 
		public   override QueryPageParameter FindWithPages(Expression<Func<Car, bool>> predicate, Func<Car, object> order,  QueryPageParameter page)
		{ 
			string cacheKey = String.Format(_pagesKeyTemplate, _key, page.PageIndex, page.PageSize, order);
			return   _cache.GetOrCreate(cacheKey,   entry =>
			{ 
				entry.SlidingExpiration = _defaultCacheDuration;
				return   base.FindWithPages(predicate, order,   page);
			});
			 
		}
		public async override Task<QueryPageParameter> FindWithPagesAsync(Expression<Func<Car, bool>> predicate, Func<Car, object> order,  QueryPageParameter page)
		{
			string cacheKey = String.Format(_pagesKeyTemplate, _key, page.PageIndex, page.PageSize, order);
			return await _cache.GetOrCreateAsync(cacheKey,async entry =>
			{
				entry.SlidingExpiration = _defaultCacheDuration;
				return await base.FindWithPagesAsync(predicate, order,  page);
			});
		}
		 
		public override List<Car> GetAllList()
		{
			string cacheKey = String.Format(_pagesKeyTemplate, _key, 0, 0, "all");
			return   _cache.GetOrCreate(cacheKey,   entry =>
			{
				entry.SlidingExpiration = _defaultCacheDuration;
				return   base.GetAllList();
			});
			 
		}

		public async override Task<Car> FindAsync(Expression<Func<Car, bool>> predicate)
		{
			var ss = predicate.Body;
			string cacheKey = String.Format(_pagesKeyTemplate, _key, 0, 0, ss);
			return await _cache.GetOrCreate(cacheKey,async entry =>
			{
				entry.SlidingExpiration = _defaultCacheDuration;
				return await base.FindAsync(predicate);
			});
		}
		public async override Task<IEnumerable<Car>> GetListByBrandName(string brandName)
		{
			string cacheKey = String.Format(_pagesKeyTemplate, _key, 0, 0, brandName);
			return await _cache.GetOrCreate(cacheKey, async entry =>
			{
				entry.SlidingExpiration = _defaultCacheDuration;
				return await base.GetListByBrandName(brandName);
			});
		}


	}
}
