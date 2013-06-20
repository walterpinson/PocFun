using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Models;

namespace Infrastructure.Data.SqlAzure
{
    public class PocFunDbContext : DbContext
    {
        public PocFunDbContext()
            : base(string.Format("name={0}", "DefaultConnectionString")) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplicant> JobApplicants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.ComplexType<Name>();
            modelBuilder.ComplexType<Address>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
