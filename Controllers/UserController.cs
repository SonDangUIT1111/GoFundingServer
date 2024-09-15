using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities;
using go_funding_server.Data;
using go_funding_server.Data.DTO;
using go_funding_server.Services;
using System.ComponentModel;

namespace go_funding_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) {
           this._userService = userService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> getUsers() {
            var user = await _userService.getAllUsersAsync();
            return Ok(user);

        }

        [HttpPost("save")]
        public async Task<IActionResult> addUser(UserDTO userDTO) {
            var user = await _userService.addUser(userDTO);
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getUser(int id)
        {
            var user = await _userService.getAllUserByIdAsync(id);
            return Ok(user);

        }
    }
}
 