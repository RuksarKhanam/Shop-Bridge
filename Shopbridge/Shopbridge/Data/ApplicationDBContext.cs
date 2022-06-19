using Microsoft.EntityFrameworkCore;
using ShopBridge.Models;

namespace Shopbridge.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {

        }
        public DbSet<ShopItem> Items { get; set; }
    }
}

