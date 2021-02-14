using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }
        public void Add(Car car)
        {
            if (car.CarName.Length >= 2 && car.DailyPrice >= 0)
            {
                _carDal.Add(car);
            }
            else
            {
                if (car.CarName.Length <= 2)
                {
                    Console.WriteLine("Araba adı min 2 karakter olmalıdır, kayıt başarısız.");
                }
                else
                {
                    Console.WriteLine("Arabanın günlük fiyatı 0'dan büyük olmalıdır, kayıt başarısız.");
                }
                
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public Car Get(int id)
        {
            return _carDal.Get(p => p.Id == id);
        }
    }
}
