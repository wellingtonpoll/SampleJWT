using Microsoft.AspNetCore.Mvc;
using SampleJWT.API.Models;
using SampleJWT.API.Services;
using System.Threading.Tasks;

namespace SampleJWT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn(SigninModel model)
        {
            if (model.UserName != "admin" || model.Password != "admin")
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var accountService = new AccountService();
            var token = await accountService.GenerateTokenAsync();

            return Ok(new { Data = token });
        }
    }
}
