using FoodAdmin.Dto.User;
using FoodAdmin.Service;
using Microsoft.AspNetCore.Mvc;

namespace FoodAdmin.Controllers
{
    [Route("api/[controller]")]
    public class EditUserController : Controller
    {
        private readonly IUserEditService _userEditService;

        public EditUserController(IUserEditService userEditService)
        {
            _userEditService = userEditService;
        }


        [HttpGet("user")]
        public EditUserDto GetUser(int userId)
        {
            return _userEditService.GetUser( userId );
        }

        [HttpPost("user")]
        public EditUserDto SaveUser([FromBody] EditUserDto newUser)
        {
            EditUserDto savedUserDto = _userEditService.SaveUser( newUser );

            return new EditUserDto
            {
                UserId = savedUserDto.UserId,
                Name = savedUserDto.Name,
                Role = savedUserDto.Role
            };
        }
    }
}