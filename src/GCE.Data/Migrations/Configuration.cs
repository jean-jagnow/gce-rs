namespace GCE.Data.Migrations
{

    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GCE.Data.GCEContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        
    }
}
