using Food.EntityFramework.Entities.Enums;

namespace FoodService.Dto.User
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
