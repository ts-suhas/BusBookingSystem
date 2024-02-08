using Microsoft.AspNetCore.Mvc;
using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Interfaces;

namespace BusBookingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }


        [HttpPost]
        [Route("token")]
        public ActionResult<LoginResponse> Login(LoginRequest request)
        {
            return _authenticationService.Login(request);
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<Identity>> AddNewUser(Identity user)
        {
            return await _authenticationService.AddNewUser(user);
        }


    }
}
