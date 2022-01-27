using Microsoft.EntityFrameworkCore;
using System.Data;
using monkey.api.Models;

namespace monkey.api.Data ;
 

public class SqlContext : DbContext
{
    public DbSet<AppUser> AppUsers { get; set; } 
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
        .UseSqlServer(System
                        .Configuration
                        .ConfigurationManager
                        .AppSettings["constr"]);
    }
} 