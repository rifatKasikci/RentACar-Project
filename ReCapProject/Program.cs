using Business.Concreate;
using DataAccess.Abstract;
using DataAccess.Concreate;
using DataAccess.Concreate.EntityFramework;
using Entities.Concreate;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            // ColorTest();

            //BrandTest();

            //CarTest();
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(new Car { Id = 11, BrandId = 8, ColorId = 3, CarName = "Ford Focus TrendX", DailyPrice = 575, ModelYear = 2021, Description = "Sedan Dizel" });
            //carManager.Add(new Car { Id = 12, BrandId = 7, ColorId = 3, CarName = "Fiat EGEA URBAN PLUS", DailyPrice = 470, ModelYear = 2020, Description = " boş açıklama" });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + "/" + car.Id);
            }
            //carManager.Update(new Car { Id = 12, BrandId = 7, ColorId = 3, CarName = "Fiat EGEA URBAN PLUS", DailyPrice = 560, ModelYear = 2020, Description = "Otomatik vites." });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + "/" + car.Id);
            }
            //carManager.Delete(new Car { Id = 12, BrandId = 7, ColorId = 3, CarName = "Fiat EGEA URBAN PLUS", DailyPrice = 560, ModelYear = 2020, Description = "Otomatik vites." });
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.CarName + "/" + car.Id);
            }
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine(car.CarId + "/" + car.CarName + "/" + car.BrandName + "/" + car.ColorName + "/" + car.DailyPrice);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBranDal());
            //brandManager.Add(new Brand { Id = 11, BrandName = "Jeep" });
            //brandManager.Add(new Brand { Id = 12, BrandName = "Bosluk" });
            //brandManager.Update(new Brand { Id = 12, BrandName = "Ferrari" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "/" + brand.BrandName);
            }
            Console.WriteLine("*****************************************");
            //brandManager.Delete(new Brand { Id = 12, BrandName = "Ferrari" });
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.Id + "/" + brand.BrandName);
            }
            Console.WriteLine("***************************************");
            Console.WriteLine(brandManager.GetById(1).BrandName);
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            // colorManager.Add(new Color { Id = 11, ColorName = "Orange" } ); 
            //colorManager.Add(new Color { Id = 12, ColorName = "Bosluk" });
            //colorManager.Update(new Color { Id = 12, ColorName = "Dark Green" });
            //colorManager.Delete(new Color { Id = 12, ColorName = "Dark Green" });

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.Id + "/" + color.ColorName);
            }

            Console.WriteLine("********************************************");

            Console.WriteLine(colorManager.GetById(7).ColorName);
        }
    }
}
