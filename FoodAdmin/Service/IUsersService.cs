using System.Collections.Generic;
using FoodAdmin.Dto.User;

namespace FoodAdmin.Service
{
    public interface IUsersService
    {
        List<UserDto> GetUsers();
    }
}