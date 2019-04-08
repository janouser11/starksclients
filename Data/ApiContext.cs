using Microsoft.EntityFrameworkCore;
using StarkIndustries.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StarkIndustries.Data
{
    public class ApiContext :DbContext
{
        public ApiContext(DbContextOptions<ApiContext> options)
           : base(options)
        {
        }

        public DbSet<Agent> Agents { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
           .HasOne(p => p.Agent)
           .WithMany(b => b.Customers)
           .HasForeignKey(p => p.Agent_id)
           .HasConstraintName("AgentIdFK");

        }
    }
}
