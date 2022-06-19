using Assignment.Model;
using Assignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _iUserService { set; get; }
        public UserController(IUserService userService)
        {
            _iUserService = userService;
        }

        [HttpPost]
        [Route("save")]
        public async Task<ActionResult> SaveUser(UserModel userModel)
        {
            try
            {
                
                if (!ModelState.IsValid)
                {
                    return BadRequest("Please fill all mandatory fields");
                }
                await _iUserService.SaveUser(userModel);
                return Ok(1);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while processing request");
            }
        }
    }
}
