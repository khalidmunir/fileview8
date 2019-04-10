namespace FileView.Repositories.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using FileView.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<FileView.Repositories.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(FileView.Repositories.DataContext context)
        {
            //  This method will be called after migrating to the latest version.


        }
    }
}
