using Microsoft.EntityFrameworkCore;

namespace YellowPage.Api.Data;
public class YellowPageDb : DbContext
{
    public YellowPageDb(DbContextOptions<YellowPageDb> options)
        : base(options)
    {
    }

    public DbSet<YellowPage.Api.Models.Person> Person { get; set; }

    public DbSet<YellowPage.Api.Models.Business> Business { get; set; }

    public DbSet<YellowPage.Api.Models.User> User { get; set; }
}
