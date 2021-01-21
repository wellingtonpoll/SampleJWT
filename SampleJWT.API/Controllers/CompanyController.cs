using Microsoft.AspNetCore.Mvc;
using SampleJWT.API.Attributes;
using System.Threading.Tasks;

namespace SampleJWT.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var company = new
            {
                Name = "ACME"
            };
            return Ok(await Task.Run(() => company));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var company = new
            {
                Id = id,
                Name = "ACME"
            };
            return Ok(await Task.Run(() => company));
        }
    }
}
