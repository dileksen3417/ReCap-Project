using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());

            Console.WriteLine("GetAll methodu ile araç listesi....");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n\nGetById methodu ile 2 nolu araç bilgisi....");
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n\nAdd methodu ile yeni araç ekleyelim....");
            Car carToAdd = new Car {Id=6, BrandId=6, ColorId=2, DailyPrice=5000, Description="Tesla", ModelYear=2021 };
            carManager.Add(carToAdd);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n\nUpdate methodu ile araç bilgilerini değiştirelim....");
            Car carToUpdate = new Car { Id = 1, BrandId = 1, ColorId = 0, DailyPrice = 2000, Description = "Changed Car", ModelYear = 2021 };
            carManager.Update(carToUpdate);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }

            Console.WriteLine("\n\nDelete methodu ile aracı sistemden silelim....");
            Car carToDelete = new Car { Id = 1, BrandId = 1, ColorId = 0, DailyPrice = 2000, Description = "Changed Car", ModelYear = 2021 };
            carManager.Delete(carToDelete);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
