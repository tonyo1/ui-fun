

using System;
using System.Net;
using Microsoft.Azure.Cosmos;
using Microsoft.EntityFrameworkCore;
using monkey.api.Models;
namespace monkey.api.Repsoitories;

public class AppUsersStore : CosmosBase
{
    public DbSet<AppUser> AppUsers { get; set; }

    public AppUsersStore(DbContextOptions options) : base(options)
    {
    }
}
public class CosmosBase : DbContext
{
    public static string DBNAME = "monkey-db";
    protected CosmosClient _cosmosClient; 
    protected Database _database; 
    public CosmosBase(DbContextOptions options) : base(options)
    {
        this._cosmosClient = this.Database.GetCosmosClient();
        this._database= this._cosmosClient.CreateDatabaseIfNotExistsAsync(DBNAME).Result;
            
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? accountEndpoint = System.Configuration.ConfigurationManager.AppSettings["EndPointUri"];
        string? primaryKey = System.Configuration.ConfigurationManager.AppSettings["PrimaryKey"];

        optionsBuilder.UseCosmos(
            accountEndpoint: accountEndpoint + string.Empty,
            accountKey: primaryKey + string.Empty,
            databaseName: DBNAME,
            options =>
            {
                options.ConnectionMode(ConnectionMode.Direct);
                options.WebProxy(new WebProxy());
                //  options.LimitToEndpoint();
                //   options.MaxRequestsPerTcpConnection(2);
                //   options.MaxTcpConnectionsPerEndpoint(2);
                //    options.IdleTcpConnectionTimeout(TimeSpan.FromMinutes(1));
                //    options.OpenTcpConnectionTimeout(TimeSpan.FromMinutes(1));
                //   options.RequestTimeout(TimeSpan.FromMinutes(1));

            });
    }

}