using Cultris_II.Services;
using Cultris_II.Views;
using Xamarin.Forms;

namespace Cultris_II.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string email;
        private string password;
        public string Email 
        {
            get => email; 
            set => SetProperty(ref email,value, "EntriesHaveText");
        }
        public string Password 
        {
            get => password;
            set => SetProperty(ref password, value, "EntriesHaveText");
        }

        public bool EntriesHaveText
        {
            get => CheckEntriesHaveText();
        }

        private bool CheckEntriesHaveText()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Command LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new Command<bool>(OnLoginClicked,CanLogin);
        }

        private bool CanLogin(bool param)
        {
            return EntriesHaveText;
        }

        private async void OnLoginClicked(bool param)
        {
            if (await AuthService.LoginUser(Email, Password))
            {
                await Shell.Current.GoToAsync($"//{nameof(AboutPage)}");
            }
            
        }
    }
}
