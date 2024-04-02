using AMXProductsCatalog.Core.Domain.Domains.Users;

namespace AMXProductsCatalog.Core.Domain.Abstractions.Application.Services
{
    public interface IUserService
    {
        Task<bool> CreateUser(User user);
        Task<User> GetUser(User user);
    }
}
