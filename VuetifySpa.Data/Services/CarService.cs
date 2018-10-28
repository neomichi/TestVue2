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
            var car= GetCarFromCarView(carView);

            if (car.Id == Guid.Empty) {
                _db.Cars.Add(car);
            }
            car.Img = Code.SaveImage64(carView.Id, carView.GetImg, carView.ImgType, _hostingEnviroment.WebRootPath, "car");
            _db.Cars.Update(car);
            _db.SaveChanges();
            return car;
        }

        ///язнаючтонадопеределать
        CarView GetCarViewFromCar(Car car)
        {
            var carview = new CarView
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
            };
            return carview;
        }
        ///язнаючтонадопеределать
        Car GetCarFromCarView(CarView car)
        {
            var car1 = new Car
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
            };
            return car1;
        }

    }
}
