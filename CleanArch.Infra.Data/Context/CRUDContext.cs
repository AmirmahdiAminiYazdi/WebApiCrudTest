using CleanArch.Domain.Models;
using CleanArch.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;


namespace CleanArch.Infra.Data.Context
{
    public class CRUDContext:DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) 
        {
            
        }
        public DbSet<Customer>  Customers{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerMapping());
        }
    }
}
