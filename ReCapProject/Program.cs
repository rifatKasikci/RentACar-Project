using Business.Concreate;
using DataAccess.Abstract;
using DataAccess.Concreate;
using System;

namespace ReCapProject
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemory());

            foreach (var car in carManager.GetById(1))
            {
                Console.WriteLine(car.Description);
            }


        }
    }
}
