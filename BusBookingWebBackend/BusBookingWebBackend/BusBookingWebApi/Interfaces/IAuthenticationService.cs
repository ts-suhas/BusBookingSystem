using Microsoft.AspNetCore.Mvc;
using BusBookingWebApi.BusinessObjects;

namespace BusBookingWebApi.Interfaces
{

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class LoginResponse
    {
        public Identity user { get; set; }
        public string token { get; set; }
    }
    public class UserRegistrationRequest
    {
        public int IdentityId { get; set; }
        public string UserName { get; set; }
        public string? UserFirst { get; set; }
        public string? UserLast { get; set; }
        public string? UserMiddle { get; set; }
        public string Password { get; set; }
        public string UserEmailAddress { get; set; }
        public bool IsVerified { get; set; }
        public string? UserPhone { get; set; }
    }


    public interface IAuthenticationService
    {
        public ActionResult<LoginResponse> Login(LoginRequest request);
        public Task<ActionResult<Identity>> AddNewUser(Identity user);
    }
}
