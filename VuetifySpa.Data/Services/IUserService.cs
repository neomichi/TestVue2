using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using VuetifySpa.Data.Models;
using VuetifySpa.Data.ViewModel;

namespace VuetifySpa.Data.Services
{
    public interface IUserService
    {
        Task<UserView> GetUserViewFromEmail(string email);
        Task<UserView> GetUserViewFromUser(ApplicationUser user);
        Task<RegisterUserView> GetUserRegViewFromUser(ApplicationUser user);

        ApplicationUser GetUserFromEmail(string email);
        ApplicationUser GetUserFromAuthLogin(AuthLoginView authLogin);


    }
}