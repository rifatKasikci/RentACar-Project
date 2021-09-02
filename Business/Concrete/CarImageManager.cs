using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        IFileHelper _fileHelper;
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
             IResult result = BusinessRules.Run(CheckImageCount(carImage.CarId));

            if (result != null)
            {
                return result;
            }
            
                var imageResult = _fileHelper.Upload(file);
                if (!imageResult.Success)
                {
                    return new ErrorResult(imageResult.Message);
                }
                carImage.ImagePath = imageResult.Message;
                _carImageDal.Add(carImage);
                return new SuccessResult(Messages.CarImageAdded);
           
            }
            
        

        public IResult Delete(CarImage carImage)
        {
            var image = _carImageDal.Get(i=>i.Id == carImage.Id);
            if (image == null)
            {
                return new ErrorResult("Image not found");
            }
            _fileHelper.Delete(image.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<CarImage> Get(int carImageid)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(i => i.Id == carImageid));
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarImageNull(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId).Data);
           
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            var isImage = _carImageDal.Get(i => i.Id == carImage.Id);
            if (isImage == null)
            {
                return new ErrorResult("Image not found");
            }
            var updatedFile = _fileHelper.Update(file, isImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        public IDataResult<List<CarImage>> CheckIfCarImageNull(int carId)
        {
            try
            {
                string path = @"\logo.jpg";
                var result = _carImageDal.GetAll(i=>i.CarId == carId).Any();
                if (!result)
                {
                    List<CarImage> carImage = new List<CarImage>();
                    carImage.Add(new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carImage);
                } 
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(i => i.CarId == carId).ToList());

        }


        public IResult CheckImageCount(int carId)
        {
           
            if (_carImageDal.GetAll(i => i.CarId == carId).Count<5)
            {
                 return new SuccessResult();
               
            }
            else {
                return new ErrorResult("A car can have at most 5 pictures");
            }
            

        }
    }
}
