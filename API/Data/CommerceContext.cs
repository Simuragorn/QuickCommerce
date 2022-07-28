using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class CommerceContext : DbContext
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}