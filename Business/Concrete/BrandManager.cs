using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new SuccessResult("Ekleme Başarılı.");

        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, "Güncellendi");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new DataResult<List<Brand>>(_brandDal.GetAll(),true);
        }

        public IDataResult<Brand> GetById(int id)
        {
            return new DataResult<Brand>(_brandDal.Get(b => b.Id == id),true);
        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true);
        }
    }
}
