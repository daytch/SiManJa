using uangsaku.Domain.Models;
using uangsaku.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace uangsaku.Infra.Data.Context
{
    public class UangsakuContext : DbContext
    {
        public UangsakuContext(DbContextOptions<UangsakuContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
