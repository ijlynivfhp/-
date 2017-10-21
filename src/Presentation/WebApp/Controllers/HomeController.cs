using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using ApplicationCore.Interfaces;
using System.Data;
using ApplicationCore.Services;
using ApplicationCore.Entities;
using MicroOrm.Dapper.Repositories;
using ApplicationCore;

namespace WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarBrandService _carBrandService;
        private readonly ICarService _carService;
          

        /// <summary>
        /// 构造注入 不懂的自己百度脑补（构造器注入的编程方式） 哈哈
        /// </summary> 
        /// <param name="carService"></param>
        //public HomeController(ICarService carService)
        //{
        //    _carService = carService;
        //    //_carBrandService = carBrandService;
        //}

        public HomeController(ICarBrandService carBrandService, ICarService carService )
        {
            this._carBrandService = carBrandService;
            this._carService = carService;
             
        }

        public async Task< IActionResult> Index()
        {
            if(!_carService.GetAllList().Any())
           await _carService.CreateAsync("五菱越野",1);//如果数据库无数据 ，先添加一条记录

           var list = _carService.GetAllList();

			var pages = new QueryPageParameter { PageIndex = 1, PageSize = 3 };


		   var bCars =await _carService.FindWithPagesAsync(x=>x.Id>4,null,  pages);

            ViewBag.car = bCars;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
