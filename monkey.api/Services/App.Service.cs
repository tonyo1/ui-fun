using monkey.api.Models;
namespace monkey.api.Services
{
    public class AppUserService
    { 
        public IList<AppUser> GetAppUsers()
        {
            return Enumerable.Range(1, 5).Select(index => new AppUser
            {
                Id = Guid.NewGuid(),
                UserName = Guid.NewGuid().ToString(),
                Email = "INeedEmail"
            })
            .ToArray();
        }
    }
}
 