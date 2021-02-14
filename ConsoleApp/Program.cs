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
            //InMemory erişim şeklini kullanarak CRUD işlemlerini gerçekleştirelim:
            CarManager carManager = new CarManager(new InMemoryCarDal());

            GetAllCarWithInMemory(carManager);
            GetCarByIdWithInMemory(carManager);
            AddCarWithInMemory(carManager);
            UpdateCarWithInMemory(carManager);
            DeleteCarWithInMemory(carManager);
        }

        private static void DeleteCarWithInMemory(CarManager carManager)
        {
            Console.WriteLine("\n\nDelete methodu ile aracı sistemden silelim....");
            Car carToDelete = new Car { Id = 1, BrandId = 1, ColorId = 0, CarName = "Changed Audi", DailyPrice = 2000, Description = "Changed Car", ModelYear = 2021 };
            carManager.Delete(carToDelete);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} : {1}", car.Id, car.CarName);
            }
        }

        private static void UpdateCarWithInMemory(CarManager carManager)
        {
            Console.WriteLine("\n\nUpdate methodu ile araç bilgilerini değiştirelim....");
            Car carToUpdate = new Car { Id = 1, BrandId = 1, ColorId = 0, CarName = "Changed Audi", DailyPrice = 2000, Description = "Changed Car", ModelYear = 2021 };
            carManager.Update(carToUpdate);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} : {1}", car.Id, car.CarName);
            }
        }

        private static void AddCarWithInMemory(CarManager carManager)
        {
            Console.WriteLine("\n\nAdd methodu ile yeni araç ekleyelim....");
            Car carToAdd = new Car { Id = 6, BrandId = 6, ColorId = 2, CarName = "Tesla 2021", DailyPrice = 5000, Description = "Elektrikli", ModelYear = 2021 };
            carManager.Add(carToAdd);
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} : {1}", car.Id, car.CarName);
            }
        }

        private static void GetCarByIdWithInMemory(CarManager carManager)
        {
            Console.WriteLine("\n\nGetById methodu ile 2 nolu araç bilgisi....");
            foreach (var car in carManager.GetById(2))
            {
                Console.WriteLine("{0} : {1}", car.Id, car.CarName);
            }
        }

        private static void GetAllCarWithInMemory(CarManager carManager)
        {
            Console.WriteLine("GetAll methodu ile araç listesi....\n");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} : {1}", car.Id, car.CarName);
            }
        }
    }
}
