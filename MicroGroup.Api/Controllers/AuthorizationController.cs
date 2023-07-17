using MicroGroup.Business.Services.Abstraction;
using MicroGroup.Model.Model.Authorize;
using MicroGroup.Model.Utilities.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace MicroGroup.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorizeService _authorizationService;

        public AuthorizationController(IAuthorizeService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            return Ok(_authorizationService.Login(loginModel));
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] PersonnelModel personnelModel)
        {
            return Ok(_authorizationService.Register(personnelModel));
        }
    }
}
