using Food.EntityFramework.Entities.Enums;

namespace FoodAdmin.Dto.User
{
    public class EditUserDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}