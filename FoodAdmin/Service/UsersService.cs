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

        public UserDto GetUser(int userId)
        {
            if (userId == 0)
            {
                return CreateUser();
            }

            User user = _userRepository.All.FirstOrDefault(item => item.Id == userId);
            if (user != null)
            {
                return Convert(user);
            }

            return null;
        }

        public UserDto SaveUser(UserDto userDto)
        {
            User user = _userRepository.GetItem(userDto.UserId) ?? new User { };
            user.Name = userDto.Name;
            user.Role = userDto.Role;
            user = _userRepository.Save(user);

            return Convert(user);
        }


        public UserDto CreateUser()
        {
            return new UserDto
            {
                UserId = 0,
                Name = string.Empty,
            };
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
                UserId = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}