using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Triperis.Models;

namespace Triperis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserAuthController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        public AppUserAuthController(UserManager<AppUser> userManager)
        {
            this._userManager = userManager;
        }   

        //GET api/AppUserAuth
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserProfile()
        {
            string userId = User.Claims.First(c => c.Type == "UserId").Value;
            var user = await _userManager.FindByIdAsync(userId);
            return Ok( new {
                UserName = user.UserName,
                Email = user.Email
            });
        }
    }
}
