
using Cultris_II.Services;
using System;
using Firebase.Auth;
using Xamarin.Forms;
using System.Threading.Tasks;

[assembly: Dependency(typeof(Cultris_II.Droid.Dependencies.FireAuth))]
namespace Cultris_II.Droid.Dependencies
{
    public class FireAuth : IAuthService
    {
        public string GetCurrentUserId()
        {
            return FirebaseAuth.Instance.CurrentUser.Uid;
        }

        public bool IsAuthenticated()
        {
            return FirebaseAuth.Instance.CurrentUser != null;
        }

        public async Task<bool> LoginUser(string email, string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}