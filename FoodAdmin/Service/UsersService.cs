using System;
using System.Collections.Generic;
using System.Linq;
using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.User;

namespace FoodAdmin.Service
{
    public class UserService : IUsersService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserDto> GetUsers()
        {
            List<User> users = _userRepository.All.ToList();

            return users.ConvertAll(Convert);
        }

        private UserDto Convert(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}