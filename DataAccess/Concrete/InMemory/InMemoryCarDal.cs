using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _car;

        public InMemoryCarDal()
        {
            _car = new List<Car>()
            {
                new Car{Id=1,BrandId=1,ColorId=1,DailyPrice=1500,Description="asdas",ModelYear=2015},
                new Car{Id=2,BrandId=2,ColorId=2,DailyPrice=3000,Description="eee",ModelYear=2017},
                new Car{Id=3,BrandId=2,ColorId=3,DailyPrice=50000,Description="gggg",ModelYear=2014}
            };
        }

        public void Add(Car car)
        {
            _car.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _car.SingleOrDefault(c => c.Id == car.Id);
            _car.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _car;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(Car car)
        {
            return _car.SingleOrDefault(c => c.Id == car.Id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate=_car.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId=car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description=car.Description;
        }
    }
}
