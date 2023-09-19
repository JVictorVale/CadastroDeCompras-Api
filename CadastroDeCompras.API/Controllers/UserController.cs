using CadastroDeCompras.Application.DTOs;
using CadastroDeCompras.Application.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CadastroDeCompras.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> PostAsync([FromForm] UserDTO userDTO)
        {
            var result = await _userService.GenerateTokenAsync(userDTO);
            if (result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result);
        }
    }
}