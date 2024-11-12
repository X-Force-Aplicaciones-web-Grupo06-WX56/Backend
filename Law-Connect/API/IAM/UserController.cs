using Microsoft.AspNetCore.Mvc;
using Law_Connect.IAM.Application.Services;
using Law_Connect.IAM.Application.DTOs;
using System.Threading.Tasks;

namespace Law_Connect.API.IAM
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            var result = await _userService.RegisterUserAsync(userDto);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Errors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }
    }
}
