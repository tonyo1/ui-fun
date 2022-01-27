
using System.Configuration;
using System;
using System.Net; 
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
namespace monkey.api.Repsoitories;

 
public class MyContext : DbContext
{
    public DbSet<AppUser> AppUsers { get; set; }

     public MyContext(DbContextOptions options) : base(options)
    {
                 
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    
    }

}