namespace monkey.api.Models;
using Newtonsoft.Json;

public class WeatherForecast
{
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }
}

public class AppUser
{
 
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }  
 
    public string UserName { get; set; } 
    public string Email { get; set; }   
    public string FirstName { get; set; }
    public string LastName { get; set; }
}