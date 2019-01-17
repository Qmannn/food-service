using FoodAdmin.Dto.User;

namespace FoodAdmin.Service
{
    public interface IUserEditService
    {
        EditUserDto GetUser(int userId);
        EditUserDto SaveUser(EditUserDto userDto);
    }
}
