using System.Collections.Generic;
using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public interface ICarService
    {
        Car CreateOrUpdate(CarView carView);
        bool IsUniqueTitle(CarValidateView CarValidate);

        List<CarView> GetAllCar();
    }
}