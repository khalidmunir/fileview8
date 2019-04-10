using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using FileView.Models;
using FileView.Repositories;
using CsvHelper;
using IO = System.IO;

namespace FileView.SeedData
{
    class Program
    {

        static void Main(string[] args)
        {
            //if(args.Length < 1 || (args[0].ToLower() != "true" || args[0].ToLower() != "false"))
            //{
            //    Console.WriteLine("Syntax: FileView.SeedData <bool ResetAll>");
            //    Console.WriteLine("eg. FileView.SeedData true");
            //    Environment.Exit(0);
            //}

            //bool resetAll = args[0].ToLower() == "true" ? true : false;
            var resetAll = true;

            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            var connectionString = args.Length > 0 ? args[0] : ConfigurationManager.ConnectionStrings[0].ToString();
            Console.WriteLine("Import Seed Data: " + connectionString);

            string csvPath = $"{Environment.CurrentDirectory}\\..\\..\\Seed_Data\\";
            string employeeCsv = $"{csvPath}employee_seed.csv";
            string fileInfoCsv = $"{csvPath}fileInfo_seed.csv";
            //IO.StreamReader sr = new IO.StreamReader(employeeCsv);
            //CsvReader reader = new CsvReader(sr);

            //IEnumerable<Employee> employees = reader.GetRecords<Employee>();
            //foreach(var employee in employees)
            //{
            //    Console.WriteLine($"Firstname: {employee.FirstName}\t LastName: {employee.LastName}");
            //}

            var employeeManager = new EmployeeManager();
            var employeeCount = 0;
            try
            {
                if(resetAll)
                {
                    Task.Run(() => employeeManager.DeleteAllEmployeeAsync()).Wait();
                    Console.WriteLine("Deleted All Employees!");
                }

                string[] contents = IO.File.ReadAllText(employeeCsv).Split('\n');
                foreach (var line in contents)
                {
                    var fields = line.Substring(0, line.Length - 1).Split(',').ToArray();
                    var employee = new Employee();
                    employee.LastLogin = Convert.ToDateTime(fields[0]);
                    employee.Id = Convert.ToInt32(fields[1]);
                    employee.FirstName = fields[3];
                    employee.LastName = fields[4];
                    employee.Email = fields[5];
                    employee.Level = Convert.ToInt32(fields[6]);
                    employee.ManagerId = Convert.ToInt32(fields[7]);
                    employee.BusinessArea = fields[9];

                    var employeeId = Task.Run(() => employeeManager.InsertEmployeeAsync(employee)).Result;
                    employeeCount++;
                    Console.WriteLine($"Inserted Employee[{employeeCount}] EmployeeId: {employeeId}");
                }
            }
            finally
            {
                employeeManager.Dispose();
            }

            var fileInfoManager = new FileInfoManager();
            var fileInfoCount = 0;
            try
            {
                if (resetAll)
                {
                    Task.Run(() => fileInfoManager.DeleteAllFileInfoAsync()).Wait();
                    Console.WriteLine("Deleted All FileInfos!");
                }

                string[] contents = IO.File.ReadAllText(fileInfoCsv).Split('\n');
                foreach (var line in contents)
                {
                    var fields = line.Substring(0, line.Length - 1).Split(',').ToArray();
                    var fileInfo = new FileInfo();
                    fileInfo.FileName = fields[0];
                    fileInfo.FilePath = fields[1];
                    fileInfo.Volume = fields[2];
                    fileInfo.Size = Convert.ToInt32(fields[3]);
                    fileInfo.CreatedTime = Convert.ToDateTime(fields[4]);
                    fileInfo.ModifiedTime = Convert.ToDateTime(fields[5]);
                    fileInfo.AccessTime = Convert.ToDateTime(fields[6]);
                    fileInfo.MD5 = fields[7];
                    fileInfo.SecurityClassification = fields[8];
                    fileInfo.BusinessClassification = fields[9];
                    fileInfo.Extension = fields[10];
                    fileInfo.MimeType = fields[11];
                    fileInfo.EmployeeId = Convert.ToInt32(fields[12]);

                    var fileInfoId = Task.Run(() => fileInfoManager.InsertFileInfoAsync(fileInfo)).Result;
                    fileInfoCount++;
                    Console.WriteLine($"Inserted FileInfo[{fileInfoCount}] FileInfoId: {fileInfoId}");
                }
            }
            finally
            {
                fileInfoManager.Dispose();
            }

            Console.WriteLine();
            Console.WriteLine($"Employees Imported: {employeeCount}");
            Console.WriteLine($"FilerInfo's Imported: {fileInfoCount}");
            Console.WriteLine();
            Console.WriteLine("Import Complete!");
        }
    }
}
