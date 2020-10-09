using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlaceMe.Core.ResourceParameters;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;

namespace PlaceMe.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private readonly IMapper mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate(UserLoginDto userLoginDto)
        {
            var userData = new User()
            {
                Email = userLoginDto.Email,
                Password = userLoginDto.Password
            };
            var user = _userService.Authenticate(userData.Email, userData.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet("metadata")]
        public IActionResult GetById([FromQuery] UserResourceParameter userResourceParameter)
        {

            var user = _userService.GetMetaData(userResourceParameter.Email);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public ActionResult Create(UserDto userDto)
        {

            var user = mapper.Map<User>(userDto);
            _userService.SignUp(user);

            return Ok("Account registered successfully");
        }


    }
}
