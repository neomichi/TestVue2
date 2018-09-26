using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data
{
    public interface IExtensionMethods
    {
        Task<RegisterUserView> GetUserRegViewFromEmail(string Email);
        Task<RegisterUserView> GetUserRegViewFromUser(ApplicationUser user);

        ApplicationUser GetUserFromEmail(string email);
        ApplicationUser GetUserFromAuthLogin(AuthLoginView authLogin);


    }
}