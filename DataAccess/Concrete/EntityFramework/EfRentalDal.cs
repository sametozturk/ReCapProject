using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal:EfEntityRepositoryBase<Rental,NorthwindContext>,IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using(NorthwindContext context=new NorthwindContext())
            {
                var result = from rentals in context.Rentals
                             join cars in context.Cars
                             on rentals.CarId equals cars.Id
                             join customer in context.Customers
                             on rentals.CustomerId equals customer.UserId
                             join users in context.Users
                             on customer.UserId equals users.Id
                             select new RentalDetailDto
                             {
                                 Id = rentals.Id,
                                 CarName = cars.CarName,
                                 RentDate = rentals.RentDate,
                                 ReturnDate = rentals.ReturnDate,
                                 UserName = users.FirstName + " " + users.Lastname
                             };
                return result.ToList();
            }
        }
    }
}
