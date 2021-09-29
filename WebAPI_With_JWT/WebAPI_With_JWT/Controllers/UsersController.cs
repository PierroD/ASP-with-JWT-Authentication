using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_With_JWT.HttpMessages.Requests;
using WebAPI_With_JWT.Models;
using WebAPI_With_JWT.Services.Interfaces;
using WebAPI_With_JWT.Utils.Enums;

namespace WebAPI_With_JWT.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest model)
        {
            var response = _userService.Login(model);

            if (response == null)
                return BadRequest(new { message = ErrorMessages.ERROR_400_BAD_NAME_OR_PASSWORD });

            return Ok(response);
        }


        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            var response = _userService.Register(user);
            if (response == null)
                return BadRequest(new { message = ErrorMessages.ERROR_500_CREATE_USER_ERROR });

            return Login(new LoginRequest { UsernameOrEmail = response.Email, Password = response.Password });
        }

        [Authorize]
        [HttpPut("{id:int}/update")]
        public IActionResult Update(int id,[FromBody] User user)
        {
            user.Id = id;
            var response = _userService.Update(user);
            if (response == null)
                return BadRequest(new { message = ErrorMessages.ERROR_500_UPDATE_USER_ERROR });

            return Ok(response);
        }

        [Authorize]
        [HttpDelete("{id:int}/delete")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }

        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

    }
}
