using OnlineShop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.DataLayer.MSSQL
{
    public class MsSqlDbContext : ApplicationDbContext
    {
        public MsSqlDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}