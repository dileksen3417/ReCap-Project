using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car { Id = 1, BrandId = 1, ColorId = 3, CarName="Audi 2019", DailyPrice = 500, Description = "Konforlu", ModelYear = 2019 },
                new Car { Id = 2, BrandId = 1, ColorId = 1, CarName="Audi 2015", DailyPrice = 300, Description = "Sahibinden sıfır", ModelYear = 2015 },
                new Car { Id = 3, BrandId = 2, ColorId = 1, CarName="Mercedes 2020", DailyPrice = 750, Description = "Full paket", ModelYear = 2020 },
                new Car { Id = 4, BrandId = 3, ColorId = 5, CarName="Volvo 1999", DailyPrice = 200, Description = "Dayanıklı", ModelYear = 1999 },
                new Car { Id = 5, BrandId = 2, ColorId = 5, CarName="Mercedes 2018", DailyPrice = 450, Description = "Güçlü", ModelYear = 2018 },
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
            carToUpdate.CarName = car.CarName;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
            carToUpdate.ModelYear = car.ModelYear;
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }
    }
}
