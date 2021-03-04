using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloggingProject.Models;
using BloggingProject.Helper;

namespace BloggingProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        IConfiguration _configuration;

        public AuthenticationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Login(UserLogin loginModel)
        {
            UserLoginHelper loginHelper = null;
            try
            {
                loginHelper = new UserLoginHelper(_configuration);
                var userLogin = loginHelper.ValidateUser(loginModel);

                if (userLogin != null && loginHelper.ValidatePassword(loginModel.Password,userLogin))
                {
                    var jsonWebToken = loginHelper.GetAuthToken(userLogin);
                    return Ok(jsonWebToken);
                }
                return Unauthorized();

            }
            catch
            {
                return StatusCode(500);//Implement logger for ui logs
            }
            
        }


         
    }
}
