namespace WhatsHoppening.Domain.UserManager.Authentication
{
    public class UserAuthenticationRequest
    {
        public UserAuthenticationRequest()
        {
            Username = string.Empty;
            Password = string.Empty;
        }

        public UserAuthenticationRequest(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }
        public string Password { get; set; }
    }
}
