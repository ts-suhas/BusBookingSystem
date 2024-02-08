using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using BusBookingWebApi.BusinessObjects;
using BusBookingWebApi.Data;
using BusBookingWebApi.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Security.Cryptography;

namespace BusBookingWebApi.Services
{
    public class AuthenticationService : Microsoft.AspNetCore.Mvc.ControllerBase, IAuthenticationService
    {
        private readonly DataContext _context;
        public AuthenticationService(DataContext context)
        {
            _context = context;
        }

        public ActionResult<LoginResponse> Login(LoginRequest loginRequest)
        {
            string token = "";

            var user = _context.Identities.Where(u => u.Email == loginRequest.Email && u.Password == ComputeHash(loginRequest.Password) && u.IsArchived != false).FirstOrDefault();
            if (user == null)
            {
                throw new Exception("Unauthorized");
            }
            token = GenerateJSONWebToken(user);
            user.Password = "";
            var loginResponse = new LoginResponse
            {
                user = user,
                token = token
            };
            return Ok(loginResponse);

        }

        public async Task<ActionResult<Identity>> AddNewUser(Identity request)
        {
            if (_context.Identities == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }
            if (_context.Identities.Where(x => x.Email == request.Email).Any())
            {
                return Problem("Email Already Taken");
            }

            var verificationCode = GenNumber(00000, 9999999);

            var user = new Identity
            {
                IdentityTypeId = request.IdentityTypeId,
                Firstname = request.Firstname,
                Lastname = request.Lastname, 
                Phone = request.Phone,
                Email = request.Email,
                Password = ComputeHash(request.Password),
                IsArchived = true
            };

            _context.Identities.Add(user);
            await _context.SaveChangesAsync();

            user.Password = "";
            return Ok(user);
        }


        public static int GenNumber(int min = 0, int max = int.MaxValue)
        {
            var Random = new Random();
            return Random.Next(min, max);
        }

        private string GenerateJSONWebToken(Identity userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisismySecretKey"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim> {
                new Claim(JwtRegisteredClaimNames.Email, userInfo.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Password),
                new Claim("DateOfJoing", new DateTime().ToString("yyyy-MM-dd")),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            if (userInfo.Email == "test@gmail.com")
            {
                claims.Add(new Claim("Role", "admin"));

            }
            else
            {
                claims.Add(new Claim("Role", "user"));

            }
            var token = new JwtSecurityToken("https://localhost:44366",
              "https://localhost:44366",
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        static string ComputeHash(string s)
        {
            string hash = String.Empty;

            // Initialize a SHA256 hash object
            using (SHA256 sha256 = SHA256.Create())
            {
                // Compute the hash of the given string
                byte[] hashValue = sha256.ComputeHash(Encoding.UTF8.GetBytes(s));

                // Convert the byte array to string format
                foreach (byte b in hashValue)
                {
                    hash += $"{b:X2}";
                }
            }

            return hash;
        }
    }
}
