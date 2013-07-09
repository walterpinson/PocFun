using System.Data.Entity;
using Core.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Data.SqlAzure
{
    public class PocFunDbContext : DbContext
    {
        public PocFunDbContext()
            : base(string.Format("name={0}", "DefaultConnection")) { }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplicant> JobApplicants { get; set; }
        public DbSet<JobApplication> JobApplications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Ensure that the GUID IDs are autopopulated
            modelBuilder.Entity<Job>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<JobApplicant>().Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            // Configure components
            modelBuilder.ComplexType<Name>();
            modelBuilder.ComplexType<Address>();

            base.OnModelCreating(modelBuilder);
        }

    }
}
