namespace AMXProductsCatalog.Core.Domain.Entities.Users
{
    public class UserEntity
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }


        public UserEntity()
        {
            
        }

        public UserEntity(int id, string username, string password, string role)
        {
            Id = id;
            Username = username;
            Password = password;
            Role = role;
        }
    }
}
