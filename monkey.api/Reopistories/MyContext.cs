
using System.Configuration;
using System;
using System.Net; 
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
namespace monkey.api.Repsoitories;

 
public class MyContext : DbContext
{
    public DbSet<AppUser> AppUsers { get; set; }
    private IConfiguration config { get; }

    public MyContext(DbContextOptions options, IConfiguration   config) : base(options)
    {
        this.config = config;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseSqlServer(this.config.GetValue<string>("ConStr"));
            
 
}