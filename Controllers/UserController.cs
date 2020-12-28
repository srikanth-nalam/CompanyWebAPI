using CompanyOwnerWebAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyOwnerWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _userlogger;
        public UserController(IUserService userService, ILogger<UserController> userlogger)
        {
            _userService = userService;
            _userlogger = userlogger;

        }

        [HttpGet("{userName}")]
        public async Task<IActionResult> VerifySSN(string userName)
        {
            var result = await _userService.VerifySSN(userName);
            if (result.Data != null)
                return Ok(await _userService.VerifySSN(userName));
            else
                return NotFound("User Name Not found");
        }

    }
}
