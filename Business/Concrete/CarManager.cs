using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IDataResult<List<Car>> GetAll()
        {

            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"asad");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id),true);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id),true);
        }
        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(),true);
        }

        [ValidationAspect(typeof(ProductValidation))]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "silindi");
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true, "güncellendi");
        }

        public IDataResult<Car> GetById(int id)
        {
            return new DataResult<Car>(_carDal.Get(c => c.Id == id),true);
        }

    }
}
