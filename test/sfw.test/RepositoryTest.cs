using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Infrastructure.Data;
using MicroOrm.Dapper.Repositories.SqlGenerator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class RepositoryTest
    {
        private ICarRepository _carRepo;
        private ICarBrandRepository _carBrandRepo;
        private IDbConnection _connection;
        private ISqlGenerator<Car> _carSqlGenerator;
        private ISqlGenerator<CarBrand> _carBrandSqlGenerator;

        public RepositoryTest()
        {
            _connection = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true;Initial Catalog=hhgDb;");

            _carSqlGenerator = new SqlGenerator<Car>(ESqlConnector.MSSQL);
            _carBrandSqlGenerator = new SqlGenerator<CarBrand>(ESqlConnector.MSSQL);
            _carRepo = new CarRepository(_connection, _carSqlGenerator);
            _carBrandRepo = new CarBrandRepository(_connection, _carBrandSqlGenerator);

            #region 表的数据库初始化
            //如果数据库无数据 ，先添加一条记录
            if (!_carBrandRepo.FindAll().Any())
            {
                var inserList = new List<CarBrand>();

                for (int i = 0; i < 10; i++)
                {
                    inserList.Add(new CarBrand { Name = "五菱越野" + i });


                }
                _carBrandRepo.BulkInsert(inserList);
            }

            //如果数据库无数据 ，先添加一条记录
            if (!_carRepo.FindAll().Any())
            {
                var inserList = new List<Car>();

                for (int i = 0; i < 10; i++)
                {
                    inserList.Add(new Car { Name = "五菱越野" + i, CarBrandId = i, });

                    createData(10);
                }
                _carRepo.BulkInsert(inserList);
            }

            void createData(int a) {
                int aa = 1;
                int z = aa + a;

            }
            #endregion


        }


        [Fact]
        public void TestFindById()
        {
            var car = _carRepo.FindById<CarBrand>(5, q => q.CarBrand);
		
            Assert.True( car.CarBrand!=null); 

        }
    }
}
