using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class CommerceContext : DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}