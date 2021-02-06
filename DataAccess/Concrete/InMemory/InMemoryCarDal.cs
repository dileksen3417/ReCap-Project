using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 3, DailyPrice = 500, Description = "Audi 1", ModelYear = 2019 },
                new Car { Id = 2, BrandId = 1, ColorId = 1, DailyPrice = 300, Description = "Audi 2", ModelYear = 2015 },
                new Car { Id = 3, BrandId = 2, ColorId = 1, DailyPrice = 750, Description = "Mercedes 1", ModelYear = 2020 },
                new Car { Id = 4, BrandId = 3, ColorId = 5, DailyPrice = 200, Description = "Volvo", ModelYear = 1999 },
                new Car { Id = 5, BrandId = 2, ColorId = 5, DailyPrice = 450, Description = "Mercedes 2", ModelYear = 2018 },
            };
        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int id)
        {
            return _cars.Where(p => p.Id == id).ToList();
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(p => p.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(p => p.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

    }
}
