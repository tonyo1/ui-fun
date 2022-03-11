
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using monkey.api.Models;
using monkey.api.Services;

namespace monkey.api;
public class JwtMiddleware
{
    public static string GenerateJwtToken(AppUser user, AppSettings _app, out DateTime expires)
    {
        // generate token that is valid for 1 minute
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_app.JWTSecret.ToString());

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = CeateIdentityClaims(user),
            Expires = DateTime.UtcNow.AddHours(1),
            Issuer = _app.JWTValidIssuer,
            IssuedAt = DateTime.UtcNow,
            Audience = _app.JWTValidAudience,
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        expires = DateTime.UtcNow.AddHours(1);
        return tokenHandler.WriteToken(token);
    }
    public static ClaimsIdentity CeateIdentityClaims(AppUser user)
    {
        var newID = new ClaimsIdentity(new[]
        {
            new Claim("username", user.UserName + string.Empty),
            new Claim("userid", user.UserId.ToString()),
            new Claim(ClaimTypes.Email, user.Email + string.Empty),
            new Claim("name", user.FirstName + string.Empty),
        });
        foreach (var role in user.Roles)
        {
            newID.AddClaim(new Claim(ClaimTypes.Role, role));
        } 
        return newID;
    }
    public static AppUser GetAppUserFromToken(JwtSecurityToken token)
    {
        return new AppUser()
        {
            UserId = int.Parse(token.Claims.First(x => x.Type == "userid").Value),
            UserName = token.Claims.First(x => x.Type == "name").Value,
            Email = token.Claims.First(x => x.Type == "email").Value,
            LastName = token.Claims.First(x => x.Type == "role").Value
        };
    }


    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, AppSettings appSettings)
    {
        _next = next;
        _appSettings = appSettings;
    }

    public async Task Invoke(HttpContext context, IAppUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            attachUserToContext(context, userService, token);

        await _next(context);
    }

    private void attachUserToContext(HttpContext context, IAppUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.JWTSecret);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            // attach user to context on successful jwt validation
            context.Items["User"] = GetAppUserFromToken(jwtToken);
        }
        catch (Exception ex)
        {
            int i = 1;
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
}

public class hhhh
{

}
