using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BiFi.Project.Data.Context
{
    public class BaseDbContext<TContext, TConfiguration> : DbContext where TContext : DbContext where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private static string _nameOrConntectionString = typeof(TContext).Name;
        public BaseDbContext() : base(_nameOrConntectionString) { }
        public BaseDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TContext, TConfiguration>());
            _nameOrConntectionString = connectionString;
        }
    }
}