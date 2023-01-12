using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //UserTest();

            //RentalTest();

        }

        private static void RentalTest()
        {
            RentalManager rentalManager = new RentalManager(new EfRentalDal());

            Rental newRentalforError = new Rental() { CarId = 1006, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = (DateTime?)null };

            var resultSave = rentalManager.Add(newRentalforError);

            Console.WriteLine(resultSave.Message);

            Rental newRental = new Rental() { Id = 5, CarId = 4, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(10) };

            var resultNewSave = rentalManager.Add(newRental);
            
            Console.WriteLine(resultNewSave.Message);

            var result = rentalManager.GetAll();

            if (result.Success == true)
            {
                foreach (var rental in result.Data)
                {
                    Console.WriteLine(rental.RentDate);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            foreach (var user in userManager.GetUserDetails().Data)
            {
                Console.WriteLine(user.FirstName + " / " + user.LastName + " / " + user.CompanyName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            var result = brandManager.GetAll();

            if (result.Success==true)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Delete(new Car {Id=3002, BrandId = 5, ColorId = 3, ModelYear = 2019, DailyPrice = 522500, Description = "q2"});

            var result = carManager.GetCarDetails();

            if (result.Success==true)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.BrandName + " / " + car.Description + " / " + car.ColorName + " / " + car.DailyPrice);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }

            
        }
    }
}
