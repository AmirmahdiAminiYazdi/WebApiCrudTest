using CleanArch.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class CRUDContext:DbContext
    {
        public CRUDContext(DbContextOptions<CRUDContext> options) : base(options) 
        {
            
        }
        public DbSet<Customer>  Customers{ get; set; }
    }
}
