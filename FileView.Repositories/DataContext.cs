using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using FileView.Models;

namespace FileView.Repositories
{
    public class DataContext: DbContext
    {
        public DataContext()
           : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
        }


        public DbSet<Employee> Employees { get; set; }
        public DbSet<FileInfo> FileInfos { get; set; }


    }
}