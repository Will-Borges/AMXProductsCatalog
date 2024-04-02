using AMXProductsCatalog.Core.Domain.Entities.Users;

namespace AMXProductsCatalog.Core.Domain.Abstractions.Repository
{
    public interface IUserRepository
    {
        Task<bool> InsertUser(UserEntity user);
        Task<bool> CheckAuthenticationUser(UserEntity user);
        Task<UserEntity> GetUser(UserEntity user);
    }
}
