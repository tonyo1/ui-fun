using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Repsoitories;

namespace monkey.api.Services
{
    public class AppUserService
    {
        public AppUserService()
        {

        }


        public IList<AppUser> GetAppUsers()
        {
            using (var context = new AppUsersStore(new DbContextOptions<CosmosBase>()))
            {
                return context.AppUsers.ToList();
            }
        }
    }
}
