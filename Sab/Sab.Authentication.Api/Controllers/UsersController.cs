using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sab.Authentication.Features.Dto;
using Sab.Authentication.Features.Helper;
using Sab.Authentication.Features.Services;
using Sab.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sab.Authentication.Api.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // custom JWT middileware
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        //[CustomAuthorize]
        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        [HttpGet("get-item")]
        public IActionResult GetItem()
        {
            return Ok("Hello from User Controller");
        }
        [Authorize]
        [HttpGet("get-top")]
        public IActionResult GetTop()
        {
            return Ok("It's Top user");
        }
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("get-admin")]
        public IActionResult GetAdmin()
        {
            return Ok("It's Admin");
        }
    }
}
