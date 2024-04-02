using AMXProductsCatalog.Views.Authentication;
using AMXProductsCatalog.Views.Users;

namespace AMXProductsCatalog.Presenters.Interfaces
{
    public interface IUserPresenter
    {
        Task<bool> CreateUser(UserDTO user);
        Task<dynamic> AuthenticateUser(UserAuthenticationDTO userDto);
    }
}
