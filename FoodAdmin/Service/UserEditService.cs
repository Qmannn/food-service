using Food.EntityFramework;
using Food.EntityFramework.Entities;
using FoodAdmin.Dto.User;
using System.Linq;

namespace FoodAdmin.Service
{
    public class UserEditService: IUserEditService
    {
        private readonly IRepository<User> _userEditRepository;

        public UserEditService(IRepository<User> userRepository)
        {
            _userEditRepository = userRepository;
        }

        public EditUserDto GetUser(int userId)
        {
            if (userId == 0)
            {
                return CreateUser();
            }

            User user = _userEditRepository.All.FirstOrDefault(item => item.Id == userId);
            if (user != null)
            {
                return Convert( user );
            }

            return null;
        }

        public EditUserDto SaveUser(EditUserDto userDto)
        {
            User user = _userEditRepository.GetItem(userDto.UserId) ?? new User {};
            user.Name = userDto.Name;
            user.Role = userDto.Role;
            user = _userEditRepository.Save(user);

            return Convert(user);
        }


        public EditUserDto CreateUser()
        {
            return new EditUserDto
            {
                UserId = 0,
                Name = string.Empty,
            };
        }

        private EditUserDto Convert( User user )
        {
            return new EditUserDto
            {
                UserId = user.Id,
                Name = user.Name,
                Role = user.Role
            };
        }
    }
}
