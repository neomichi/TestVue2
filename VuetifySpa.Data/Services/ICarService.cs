using VuetifySpa.Data.Model;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public interface ICarService
    {
        Car Update(CarView carView);
    }
}