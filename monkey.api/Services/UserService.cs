using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using monkey.api.Models;

namespace monkey.api.Services;
public interface IAppUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<AppUser> GetAll();
    AppUser GetById(int id);
}

public class AppUserService : IAppUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<AppUser> _users = new List<AppUser>
    {
        new AppUser { UserId = 1, FirstName = "Test", LastName = "User", UserName = "test" }
        ,new AppUser { UserId = 2, FirstName = "Test", LastName = "User", UserName = "string" }

    };

    private readonly IConfiguration _appSettings;

    public AppUserService(IConfiguration appConfig)
    {
        _appSettings = appConfig;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.UserName == model.UserName && model.Password == model.Password);

        // return null if user not found
        if (user == null) return null;
 
        return new AuthenticateResponse(user);
    }

    public IEnumerable<AppUser> GetAll()
    {
        return _users;
    }

    public AppUser GetById(int userId)
    {
        return _users.FirstOrDefault(x => x.UserId == userId);
    }

    // helper methods

    private string GenerateJwtToken(AppUser user)
    {
        // generate token that is valid for 1 minute
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.GetValue<string>("JWTSecret"));

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = CreateClaimIdentity(user),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private ClaimsIdentity CreateClaimIdentity(AppUser user)
    {
        var newID = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Name, user.UserName + string.Empty),
            new Claim("userid", user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email + string.Empty),
            new Claim(ClaimTypes.Role, "user") // dynamic role assignment

        });
        return newID;
    }
}