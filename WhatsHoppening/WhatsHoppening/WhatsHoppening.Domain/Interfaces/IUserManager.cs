using WhatsHoppening.Domain.UserManager.Authentication;

namespace WhatsHoppening.Domain.Interfaces
{
    public interface IUserManager
    {
        User GetUser();
        User GetUser(int id);
        User GetUser(string username);
        void SaveUser(User user);
        User OpenAccount(Registration registration);
        bool UsernameExists(string username);
        UserAuthenticationResponse Authenticate(UserAuthenticationRequest userAuthenticationRequest);
    }
}
