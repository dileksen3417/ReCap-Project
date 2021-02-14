using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ////EntityFramework erişim şeklini kullanarak CRUD işlemlerini gerçekleştirelim:
            CarManager carManager = new CarManager(new EfCarDal());
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");

            //AddNewCarWithEf(carManager);

            //CheckCarNameLenght(carManager);

            //CheckCarDailyPrice(carManager);

            //UpdateCarWithEf(carManager);

            //DeleteCarWithEf(carManager);

            Console.WriteLine("\nBrandId = 11 olan araçları listeleyelim:");
            foreach (var car in carManager.GetCarsByBrandId(11))
            {
                Console.WriteLine("{0} / {1}", car.BrandId, car.CarName);
            }

            Console.WriteLine("\nColorId = 3 olan araçları listeleyelim:");
            foreach (var car in carManager.GetCarsByColorId(3))
            {
                Console.WriteLine("{0} / {1}", car.ColorId, car.CarName);
            }


            ////InMemory erişim şeklini kullanarak CRUD işlemlerini gerçekleştirelim:
            //CarManager carManager = new CarManager(new InMemoryCarDal());

            //GetAllCarWithInMemory(carManager);
            //GetCarByIdWithInMemory(carManager);
            //AddCarWithInMemory(carManager);
            //UpdateCarWithInMemory(carManager);
            //DeleteCarWithInMemory(carManager);
        }

        private static void DeleteCarWithEf(CarManager carManager)
        {
            Console.WriteLine("\nAracı databaseden silelim:");
            carManager.Delete(new Car { Id = 3, BrandId = 3, ColorId = 5, CarName = "Güncellenen Araç", DailyPrice = 5000, Description = "Şimdi güncellendi", ModelYear = 2022 });
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");
        }

        private static void UpdateCarWithEf(CarManager carManager)
        {
            Console.WriteLine("\nAracı güncelleyelim:");
            carManager.Update(new Car { Id = 3, BrandId = 3, ColorId = 5, CarName = "Güncellenen Araç", DailyPrice = 5000, Description = "Şimdi güncellendi", ModelYear = 2022 });
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");
        }

        private static void CheckCarDailyPrice(CarManager carManager)
        {
            Console.WriteLine("\nGünlük bedeli 0TL'den az olan araç ekleyelim:");
            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "Yeni Araç", DailyPrice = -100, Description = "Yeni eklendi", ModelYear = 2021 });
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");
        }

        private static void CheckCarNameLenght(CarManager carManager)
        {
            Console.WriteLine("\nAraç adı 2 karakterden az olan araç ekleyelim:");
            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "Y", DailyPrice = 100, Description = "Yeni eklendi", ModelYear = 2021 });
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");
        }

        private static void AddNewCarWithEf(CarManager carManager)
        {
            Console.WriteLine("\nYeni Araç Ekleyelim:");
            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "Yeni Araç", DailyPrice = 100, Description = "Yeni eklendi", ModelYear = 2021 });
            ListCars(carManager);
            Console.WriteLine("-----------------------------\n");
        }

        private static void ListCars(CarManager carManager)
        {
            Console.WriteLine("Araç Listesi:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("{0} / {1} : {2}", car.CarName, car.ModelYear, car.DailyPrice);
            }
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

        //private static void GetCarByIdWithInMemory(CarManager carManager)
        //{
        //    Console.WriteLine("\n\nGetById methodu ile 2 nolu araç bilgisi....");
        //    foreach (var car in carManager.GetById(2))
        //    {
        //        Console.WriteLine("{0} : {1}", car.Id, car.CarName);
        //    }
        //}

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
