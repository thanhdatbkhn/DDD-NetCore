using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using iStorage.Business.Services;

namespace IStorage.Controllers
{
    //[Route("user/[action]")]
    public class UsersController : ControllerBase
    {
        private readonly ITokensService _tokenService;
        private readonly IUsersService _userService;
        public UsersController(ITokensService tokenservice, IUsersService userService)
        {
            _tokenService = tokenservice;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return Ok(200);
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult Register([FromBody] JObject registrationInfo)
        {
            if (registrationInfo == null)
            {
                return BadRequest();
            }
            JToken userNameTk = registrationInfo.GetValue("UserName");
            JToken emailTk = registrationInfo.GetValue("Email");
            JToken passwordTk = registrationInfo.GetValue("Password");
            JToken confirmPasswordTk = registrationInfo.GetValue("ConfirmPassword");
            if (userNameTk == null || emailTk == null || passwordTk == null || confirmPasswordTk == null)
            {
                return BadRequest();
            }
            string userName = userNameTk.Value<string>();
            string email = emailTk.Value<string>();
            string password = passwordTk.Value<string>();
            string confirmPassword = confirmPasswordTk.Value<string>();
            if (password != confirmPassword)
            {
                return Ok("Password and confirm password are not the same!");
            }
            var userId = _userService.Authenticate(userName, password);
            if (userId != -1)
            {
                return Ok("User name is already registered!");
            }
            _userService.Register(userName, password, email);
            return Ok();
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login([FromBody] JObject loginInfo)
        {
            if (loginInfo == null)
            {
                return BadRequest();
            }
            JToken userName = loginInfo.GetValue("UserName");
            JToken password = loginInfo.GetValue("Password");
            if (userName == null || password == null)
            {
                return BadRequest();
            }
            var userId = _userService.Authenticate(userName.Value<string>(), password.Value<string>());
            if (userId == -1 )
            {
                return NotFound("User name or password is wrong!");
            }
            return Ok(_tokenService.GenerateToken(userId));
        }
    }
}
