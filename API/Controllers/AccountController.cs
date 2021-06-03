using System.Security.Cryptography;
using System.Net;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using API.DTO;
using Microsoft.EntityFrameworkCore;
using API.Interfaces;

namespace API.Controllers
{
    public class AccountController: BaseApiController
    {
        private readonly DataContext _context;
        private readonly iTokenService _tokenService;
        public AccountController(DataContext context, iTokenService tokenService)
        {
            _context = context;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegistrationDto registration)
        {
            if(await UserExists(registration.UserName))
            {
                return BadRequest("Account name already in use");
            }
            using var hmac = new HMACSHA512();
              var user = new AppUser{
                  UserName = registration.UserName.ToLower(),
                  PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registration.Password)),
                  PasswordSalt = hmac.Key
              };
              _context.Users.Add(user);
              await _context.SaveChangesAsync();
              return new UserDto{
                  Username = user.UserName,
                  Token = _tokenService.CreateToken(user)
              };
        }
        private async Task<bool> UserExists(string username){
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto userLogin)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.UserName == userLogin.UserName);
            if(user == null)
            {
                return Unauthorized("User name or password incorect");
            }
            
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userLogin.Password));
            for(int i = 0; i < passwordHash.Length; i++){
                if(passwordHash[i]!= user.PasswordHash[i]){
                    return Unauthorized("User name or password incorect");
                }
            }
            return new UserDto{
                  Username = user.UserName,
                  Token = _tokenService.CreateToken(user)
              };
        }
    }
}