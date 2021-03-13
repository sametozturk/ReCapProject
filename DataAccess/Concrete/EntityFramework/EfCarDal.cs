using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands                             
                             on c.BrandId equals b.Id
                             join c1 in context.Colors 
                             on c.ColorId equals c1.Id
                             select new CarDetailDto { BrandName=b.BrandName,ColorName=c1.ColorName,CarName=c.CarName,Id=c.Id};
                return result.ToList();
            }
        }
    }
}
