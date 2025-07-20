using Azure.Core.Pipeline;
using Backend.Entity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Dbcontext
{
    public class AppSetting: DbContext
    {
        public AppSetting(DbContextOptions<AppSetting> option):base(option)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<User> User { get; set; }
    }
}
