using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
using monkey.api.Repsoitories;

namespace monkey.api.Services
{
    public class AppUserServicexxx
    {
        private readonly MyContext _context;

        public AppUserServicexxx(MyContext context)
        {
            _context = context;
        }
 
        public IList<AppUser> GetAppUsers()
        {
             
                return _context
                .AppUsers
                .ToList();
            
        }
    }
}
