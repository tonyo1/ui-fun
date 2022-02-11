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
        this.JWTValidIssuer = _configuration.GetValue<string>("JWTValidIssuer");


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
    [JsonProperty("userId")]
    [Key]
    public int UserId { get; set; }
    [JsonProperty("username")]
    public string UserName { get; set; }
    [JsonProperty("email")]
    public string Email { get; set; }
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    [JsonProperty("lastName")]
    public string LastName { get; set; }

    [JsonProperty("roles")]
    public List<string> Roles { get; set; } = new List<string>();
}


public class AuthenticateResponse : AppUser
{
    public AuthenticateResponse(AppUser user)
    {
        UserId = user.UserId;
        FirstName = user.FirstName;
        LastName = user.LastName;
        UserName = user.UserName;
    }
}

public class AuthenticateRequest
{
    [Required]
    public string UserName { get; set; }

    [Required]
    public string Password { get; set; }
}