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
            _cars = new List<Car>
            {
                new Car{BrandId = 1, ColorId = 10, DailyPrice = 550000, Description = "Mercedes", Id = 1, ModelYear = 2010 },
                new Car{BrandId = 2, ColorId = 15, DailyPrice = 1550000, Description = "Audi", Id = 2, ModelYear = 2018 },
                new Car{BrandId = 3, ColorId = 12, DailyPrice = 650000, Description = "Bmw", Id = 3, ModelYear = 2012 },
                new Car{BrandId = 4, ColorId = 13, DailyPrice = 550000, Description = "Volvo", Id = 4, ModelYear = 2015 },
                new Car{BrandId = 5, ColorId = 14, DailyPrice = 350000, Description = "Fiat", Id = 5, ModelYear = 2009 }
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.Id == car.Id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAllByBrand(int brandId)
        {
           return _cars.Where(c => c.BrandId == brandId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.Description = car.Description;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
        }
    }
}
