using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Triperis.Models;

namespace Triperis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AppUserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }

        // POST: api/AppUser/Register
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(AppUserRegisterDto newUser)
        {
            var user = new AppUser()
            {
                UserName = newUser.UserName,
                Email = newUser.Email,
                CanCreateListings = true
            };

            var result = await _userManager.CreateAsync(user, newUser.Password);
            return Ok(result);
        }
    }
}
