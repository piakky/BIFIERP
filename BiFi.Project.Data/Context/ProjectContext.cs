using BiFi.Project.Data.ProjectMigration;
using BiFi.Project.Model.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace BiFi.Project.Data.Context
{
    public class ProjectContext : BaseDbContext<ProjectContext, Configuration>
    {
        public ProjectContext()
        {

            Configuration.LazyLoadingEnabled = false;
        }

        public ProjectContext(string connectionString) : base(connectionString)
        {
            Configuration.LazyLoadingEnabled = false;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }
        public DbSet<Province> Province { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Uom> Uom { get; set; }
    }
}