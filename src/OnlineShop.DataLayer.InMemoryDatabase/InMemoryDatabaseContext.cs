using OnlineShop.DataLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.DataLayer.InMemoryDatabase
{
    public class InMemoryDatabaseContext : ApplicationDbContext
    {
        public InMemoryDatabaseContext(DbContextOptions options) : base(options)
        {
        }
    }
}