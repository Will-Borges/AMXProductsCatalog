using AMXProductsCatalog.Core.Domain.Domains.Users;
using AMXProductsCatalog.Views.Authentication;
using AMXProductsCatalog.Views.Users;

namespace AMXProductsCatalog.Presenters.Interfaces
{
    public interface IUserPresenter
    {
        Task<bool> CreateUser(UserDTO user);
        Task<string> AuthenticateUser(UserAuthenticationDTO userDto);
    }
}
