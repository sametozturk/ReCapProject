using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(true, "eklendi");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, "eklendi");
        }

        public IDataResult<List<Color>> GetAll()
        {
            return new DataResult<List<Color>>(_colorDal.GetAll(), true);
        }

        public IDataResult<Color> GetById(int id)
        {
            return new DataResult<Color>(_colorDal.Get(c=>c.Id==id),true);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, "eklendi");
        }
    }
}
