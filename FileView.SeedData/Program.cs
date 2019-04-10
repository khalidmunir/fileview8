using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileView.Models;
using FileView.Repositories;

namespace FileView.SeedData
{
    class Program
    {

        static async Task Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            var connectionString = args.Length > 0 ? args[0] : ConfigurationManager.ConnectionStrings[0].ToString();
            Console.WriteLine("Import Seed Data: " + connectionString);
            Console.ReadKey();


            IFileInfo _fileInfoManager = new FileInfoManager();
            IEmployee _employeeManager = new EmployeeManager();

            await _employeeManager.InsertEmployeeAsync(new Employee() { Id = 4, FirstName = "DavidX", LastLogin = DateTime.Now, ManagerId = 0, Level = 0 });
            await _fileInfoManager.InsertFileInfoAsync(new FileInfo() { Id = 5, EmployeeId = 1, FilePath = @"FolderA\FolderX", Volume = @"\\192.168.0.1\C$\", FileName = "FileA.Doc", AccessTime = DateTime.Now, CreatedTime = DateTime.Now, ModifiedTime = DateTime.Now, Size = 0 });

            _employeeManager.Dispose();
            _fileInfoManager.Dispose();

            //var filename = Environment.CurrentDirectory + @"\Seed_Data\employee_seed.csv";

            //string[] contents = File.ReadAllText(filename).Split('\n');
            //var csv = from line in contents
            //          select line.Split(',').ToArray();

            //Trace.WriteLine(filename);
            //Trace.WriteLine(contents);


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.


            Console.ReadKey();



            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }
}
