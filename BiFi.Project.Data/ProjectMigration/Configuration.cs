using BiFi.Project.Data.Context;
using System;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BiFi.Project.Data.ProjectMigration
{
    public class Configuration : DbMigrationsConfiguration<ProjectContext>
    {
        public Configuration()
        {
            //We allow for automatic migration of migration processes
            AutomaticMigrationsEnabled = true;
            //We allow data loss while migrating. Why is that ? For example, we wrote tc as a string in the entity, then we turned longa and lost in this case.
            AutomaticMigrationDataLossAllowed = true;
        }
    }
}