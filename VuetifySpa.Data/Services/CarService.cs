using System;
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

        public Car Update(CarView carView)
        {
            var car= GetToCar(carView);

            if (car.Id == Guid.Empty) {
                _db.Cars.Add(car);
            } else
            {
                _db.Cars.Update(car);
            }            
            carView.Img = Code.SaveImage64(carView.Id, carView.GetImg, carView.ImgType, _hostingEnviroment.WebRootPath, "car");
            _db.SaveChanges();

            return car;
        }

        ///язнаючтонадопеределать
        CarView GetToCarView(Car car)
        {
            var carview = new CarView
            {
                Id = car.Id,
                Status = car.Status,
                BirthYear = car.BirthYear,
                CarCase = car.CarCase,
                CarType = car.CarType,
                Img = car.CarType,
                Title = car.Title,
                Transmission = car.Transmission,
                Motor = car.Motor,
                Description = car.Description,
                Color=car.Color,
                Quantity=car.Quantity,
                Visible=car.Visible,
            };
           
            return carview;
        }
        ///язнаючтонадопеределать
        Car GetToCar(CarView carView)
        {
            var car = new Car
            {
                Id = carView.Id,
                Status = carView.Status,
                BirthYear = carView.BirthYear,
                CarCase = carView.CarCase,
                CarType = carView.CarType,           
                Title = carView.Title,
                Transmission = carView.Transmission,
                Motor = carView.Motor,
                Description = carView.Description,
                Color = carView.Color,
                Quantity = carView.Quantity,
                Visible = carView.Visible,
            };            
            return car;
        }

    }
}
