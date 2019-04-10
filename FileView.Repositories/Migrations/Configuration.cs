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

            var employees = new List<Employee>
                        {
                            new Employee() {Id = 1, FirstName="David", LastLogin=DateTime.Now, ManagerId=0, Level=0},
                            new Employee() {Id = 2, FirstName="Khalid", LastLogin=DateTime.Now, ManagerId=0, Level=0},
                            new Employee() {Id = 3, FirstName="George", LastLogin=DateTime.Now, ManagerId=0, Level=0}

                        };


            var fileInfos = new List<Models.FileInfo>
                        {
                            new Models.FileInfo() {Id=1, EmployeeId=1, FilePath= @"FolderA\FolderB", Volume = @"\\192.168.0.1\C$\", FileName="FileA.Doc", AccessTime=DateTime.Now, CreatedTime=DateTime.Now, ModifiedTime=DateTime.Now, Size=0 },
                            new Models.FileInfo() {Id=2, EmployeeId=1, FilePath= @"FolderB\FolderB", Volume = @"\\192.168.0.1\\D$\", FileName="FileB.Doc", AccessTime=DateTime.Now, CreatedTime=DateTime.Now, ModifiedTime=DateTime.Now, Size=0},
                            new Models.FileInfo() {Id=3, EmployeeId=2, FilePath= @"FolderC\FolderD", Volume = @"\\192.168.0.1\E$\", FileName="FileC.Doc", AccessTime=DateTime.Now, CreatedTime=DateTime.Now, ModifiedTime=DateTime.Now, Size=0},
                            new Models.FileInfo() {Id=4, EmployeeId=3, FilePath= @"FolderD\FolderF", Volume = @"\\192.168.0.2\C$\", FileName="FileD.Doc", AccessTime=DateTime.Now, CreatedTime=DateTime.Now, ModifiedTime=DateTime.Now, Size=0}
                        };

            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            //var filename = Environment.CurrentDirectory + @"\Seed_Data\employee_seed.csv";

            //string[] contents = File.ReadAllText(filename).Split('\n');
            //var csv = from line in contents
            //          select line.Split(',').ToArray();

            //Trace.WriteLine(filename);
            //Trace.WriteLine(contents);


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Employees.AddRange(employees);
            context.FileInfos.AddRange(fileInfos);
            context.SaveChanges();

        }
    }
}
