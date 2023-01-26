using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Authentication;
using System.Linq;
using System.Threading.Tasks;

namespace Global_Superstore_ApiProject.Controllers
{
    public class UsersController : ControllerBase
    {
        private readonly AuthenticationService authenticationService;

        public UsersController(AuthenticationService authenticationService)
        {
            this.authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AuthVM auth)
        {
            var authResult = await this.authenticationService.RegisterAsync(auth.Username, auth.Password);

            if (!authResult.Succeeded)
            {
                authResult.Errors.ToList().ForEach(x =>
                {
                    this.ModelState.AddModelError(x.Code, x.Description);
                });

                return this.BadRequest(this.ModelState);
            }

            return this.Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(AuthVM auth)
        {
            var jwt = await this.authenticationService.LoginAsync(auth.Username, auth.Password);

            return this.Ok(jwt);
        }
    }
}
