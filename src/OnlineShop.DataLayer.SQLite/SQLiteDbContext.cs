using OnlineShop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Common.EFCoreToolkit;

namespace OnlineShop.DataLayer.SQLite
{
    public class SQLiteDbContext:ApplicationDbContext
    {
        public SQLiteDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.AddDateTimeOffsetConverter();
        }
    }
}