using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Cultris_II.Services
{
    public interface IAuthService
    {
        Task<bool> LoginUser(string username, string password);
        bool IsAuthenticated();

        string GetCurrentUserId();
    }
    public class AuthService
    {
        private static readonly IAuthService auth = DependencyService.Get<IAuthService>();

        public static async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                return await auth.LoginUser(email, password);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
                return false;
            }
        }

        public static bool IsAuthenticated()
        {
            return auth.IsAuthenticated();
        }

        public static string GetCurrentUserId()
        {
            return auth.GetCurrentUserId();
        }
    }
}
