using AutoMapper;

namespace AMXProductsCatalog.Presenters.Users
{
    using AMXProductsCatalog.Authentication;
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Domains.Users;
    using AMXProductsCatalog.Presenters.Interfaces;
    using AMXProductsCatalog.Views.Authentication;
    using AMXProductsCatalog.Views.Users;

    public class UserPresenter : IUserPresenter
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;


        public UserPresenter(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }


        public async Task<bool> CreateUser(UserDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);

            var createWithSucess = await _userService.CreateUser(user);
            return createWithSucess;
        }

        public async Task<string> AuthenticateUser(UserAuthenticationDTO userDto)
        {
            var user = await GetUser(userDto);

            var token = TokenService.GenerateToken(user);
            return token;
        }

        private async Task<User> GetUser(UserAuthenticationDTO userDto)
        {
            var user = _mapper.Map<User>(userDto);
            return await _userService.GetUser(user);
        }
    }
}
