using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Dto.User
{
    public class UserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
