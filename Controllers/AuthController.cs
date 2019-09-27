using System.Linq;
using introtoauth;
using IntroToAuth.Models;
using IntroToAuth.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IntroToAuth.Controllers
{
  [ApiController]
  [Route("auth")]
  public class AuthController : ControllerBase
  {
    private DatabaseContext context;

    public AuthController(DatabaseContext _context)
    {
      this.context = _context;
    }


    [HttpPost("login")]
    public ActionResult Login([FromBody] RegisterViewModel userData)
    {
      var user = context.Users.FirstOrDefault(f => f.Email.ToLower() == userData.Email.ToLower());
      if (user == null)
      {
        return BadRequest(new { message = "User is not found" });
      }
      else
      {
        var passwordResult = new PasswordHasher<User>().VerifyHashedPassword(user, user.HashedPassword, userData.Password);
        if (passwordResult == PasswordVerificationResult.Failed)
        {
          return BadRequest(new { message = "password was incorrect" });
        }
      }
    }
  }
}