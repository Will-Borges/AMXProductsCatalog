using AutoMapper;

namespace AMXProductsCatalog.Core.Application.Services.Users
{
    using AMXProductsCatalog.Core.Domain.Abstractions.Application.Services;
    using AMXProductsCatalog.Core.Domain.Abstractions.Repository;
    using AMXProductsCatalog.Core.Domain.Domains.Users;
    using AMXProductsCatalog.Core.Domain.Entities.Users;
    using System;

    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<bool> CreateUser(User user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            var createWithSucess = await _userRepository.InsertUser(userEntity);
            return createWithSucess;
        }

        public async Task<User> GetUser(User userInput)
        {
            var userEntity = _mapper.Map<UserEntity>(userInput);

            await CheckAuthenticationUser(userEntity);
            var user = await RepositoryGetUser(userEntity);
            return user;
        }

        private async Task CheckAuthenticationUser(UserEntity userEntity)
        {
            var userExist = await _userRepository.CheckAuthenticationUser(userEntity);
            VerifyUser(userExist);
        }

        private async Task<User> RepositoryGetUser(UserEntity userInput)
        {
            var userOutput = await _userRepository.GetUser(userInput);

            var user = _mapper.Map<User>(userOutput);
            return user;
        }

        private void VerifyUser(bool userExist)
        {
            if (!userExist)
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
        }
    }
}
