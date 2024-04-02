namespace AMXProductsCatalog.Adapters.Persistence.Data.Repositorys.Users
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Generics.Ramdom;
    using AMXProductsCatalog.Core.Domain.Entities.Users;

    public class UserRepository : IUserRepository
    {
        public async Task<bool> InsertUser(UserEntity user)
        {
            try
            {
                user.Id = RandomIdGenerator.GenerateId();

                AMXDatabase.Users.Add(user);
                return true;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error inserting user.");
            }
        }

        public async Task<bool> CheckAuthenticationUser(UserEntity user)
        {
            try
            {
                bool userExist = AMXDatabase.Users.Any(q => q.Password == user.Password && q.Username == user.Username);
                return userExist;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to authenticate user.");
            }
        }

        public async Task<UserEntity> GetUser(UserEntity user)
        {
            try
            {
                var userExist = AMXDatabase.Users.FirstOrDefault(q => q.Password == user.Password && q.Username == user.Username);
                return userExist;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to authenticate user.");
            }
        }
    }
}
