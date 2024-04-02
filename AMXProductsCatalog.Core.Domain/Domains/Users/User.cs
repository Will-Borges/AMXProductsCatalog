namespace AMXProductsCatalog.Core.Domain.Domains.Users
{
    public class User
    {
        public long Id { get; }
        public string Username { get; }
        public string Password { get; }
        public string Role { get; }

        public User()
        {
            
        }

        public User(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
