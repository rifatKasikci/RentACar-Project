﻿using Business.Abstract;
using Business.ValidationAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Concrete;
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

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult();
             
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult();

        }

        public IDataResult<List<Color>> GetAll()
        {
          return new SuccessDataResult<List<Color>>(_colorDal.GetAll());
        }

        public IDataResult<Color> GetById(int id)
        {
             
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.Id == id));
        }

        [ValidationAspect(typeof(ColorValidator))]
        [SecuredOperation("admin")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult();
        }
    }
}
