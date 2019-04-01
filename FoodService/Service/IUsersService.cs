using System.Collections.Generic;
using FoodService.Dto.User;

namespace FoodService.Service
{
    public interface IUsersService
    {
        List<UserDto> GetUsers();
    }
}