using System;

namespace FoodService.Domain.Exceptions
{
    public class UserNotExistException: Exception
    {
        public UserNotExistException(int userId) : base($"Пользователь с id = {userId} не найдено")
        {
        }
    }
}
