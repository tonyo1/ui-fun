namespace monkey.api.Models;

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


public class AppSettings
{
    private readonly IConfiguration _configuration;

    public AppSettings(IConfiguration configuration)
    {
        _configuration = configuration;
        this.JWTSecret = _configuration.GetValue<string>("JWTSecret");
        this.ConnectionString = _configuration.GetValue<string>("ConnectionString");
        this.JWTValidateIssuerSigningKey = _configuration.GetValue<string>("JWTValidateIssuerSigningKey");
        this.JWTValidateIssuer = _configuration.GetValue<bool>("JWTValidateIssuer");
        this.JWTValidateAudience = _configuration.GetValue<bool>("JWTValidateAudience");
        this.JWTValidAudience = _configuration.GetValue<string>("JWTValidAudience");
        this.JWTRequireExpirationTime = _configuration.GetValue<bool>("JWTRequireExpirationTime");
        this.JWTValidateLifetime = _configuration.GetValue<bool>("JWTValidateLifetime");
        

    }
    public string ConnectionString { get; set; }  
    public string ConfigName { get; set; }
 
    public object Logging { get; set; }
    public string JWTSecret { get; set; }
    public string JWTValidateIssuerSigningKey { get; set; }
    public bool JWTValidateIssuer { get; set; }
    public string JWTValidIssuer { get; set; } 
    public bool JWTValidateAudience { get; set; }

    public string JWTValidAudience { get; set; }

    public bool JWTRequireExpirationTime { get; set; }
    public bool JWTValidateLifetime { get; set; }

}



public class AppUser
{
    [Key]
    public int UserId { get; set; }

    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

     public string Token { get; set; }
}


public class AuthenticateResponse : AppUser
{
    public AuthenticateResponse(AppUser user, string token)
    {
        UserId = user.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
        Token = token;
    }
}

public class AuthenticateRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}