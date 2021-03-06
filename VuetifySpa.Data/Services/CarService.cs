﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public class CarService : ICarService
    {
        private IHostingEnvironment _hostingEnviroment;
        private MyDbContext _db;
        public CarService(MyDbContext db, IHostingEnvironment hostingEnviroment)
        {
            _db = db;
            _hostingEnviroment = hostingEnviroment;
        }

        public List<Car> GetCar()
        {

            return _db.Cars.Where(x => x.Visible).ToList();
        }

        public Car CreateOrUpdate(CarView carView)
        {
            

            var car= GetCar(carView);
            var id = carView.Id;
            if (car.Id == Guid.Empty) {
                _db.Cars.Add(car);
                id = car.Id;
                car.CreateIt = new DateTime();
            } else
            {
                _db.Cars.Update(car);
            }
            car.Img = Code.SaveImage64(id, carView.GetImg, carView.ImgType, _hostingEnviroment.WebRootPath, "car");   
            
            _db.SaveChanges();
            return car;
        }

        public bool IsUniqueTitle(CarValidateView CarValidate)
        {
            if (!string.IsNullOrEmpty(CarValidate.Title))
            {
                var title2 = CarValidate.Title.Replace(" ", "");

                if (!_db.Cars.Any(x => x.Id!=CarValidate.Id &&
                (x.Title.Equals(CarValidate.Title, StringComparison.OrdinalIgnoreCase)
              || x.Title.Equals(title2, StringComparison.OrdinalIgnoreCase))

                ))
                {
                    return true;
                }
            }
            return false;
        }

        public List<CarView> GetAllCar ()
        {
           return _db.Cars.Where(x => x.Visible).ToList().Select(x => GetCarView(x)).ToList();
        }


        ///язнаючтонадопеределать
        CarView GetCarView(Car car)
        {
            return new CarView
            {
                Id = car.Id,
                Status = car.Status,
                BirthYear = car.BirthYear,
                CarClass = car.CarClass,
                CarType = car.CarType,
                Title = car.Title.ToLower(),/////to lower url
                Transmission = car.Transmission,
                Motor = car.Motor,
                Description = car.Description,
                Color = car.Color,
                Quantity = car.Quantity,
                Visible = car.Visible,
                Mileage=car.Mileage,
                ShowInMain=car.ShowInMain,
                CreateIt=car.CreateIt,
                GetImg= string.Format("/img/car/{0}?v={1:yyyyMMddHHmmssff}",car.Img, DateTime.Now)
            };           
        }
        ///язнаючтонадопеределать
        Car GetCar(CarView car)
        {
            return new Car
            {
                Id = car.Id,
                Status = car.Status,
                BirthYear = car.BirthYear,
                CarClass = car.CarClass,
                CarType = car.CarType,           
                Title = car.Title,
                Transmission = car.Transmission,
                Motor = car.Motor,
                Description = car.Description,
                Color = car.Color,
                Quantity = car.Quantity,
                Visible = car.Visible,
                Mileage = car.Mileage,
                ShowInMain = car.ShowInMain,
            };             
        }       

    }
}
