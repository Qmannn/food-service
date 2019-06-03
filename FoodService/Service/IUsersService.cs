using System.Collections.Generic;
using Food.EntityFramework.Entities;
using FoodService.Dto.User;

namespace FoodService.Service
{
    public interface IUsersService
    {
        List<UserDto> GetUsers();
    }
}