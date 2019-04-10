using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;
using System.Threading.Tasks;
using FileView.Models;

namespace FileView.Repositories
{
    public class EmployeeManager : IEmployee
    {
        private readonly DataContext _dataContext;

        public EmployeeManager()
        {
            _dataContext = new DataContext();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public async Task<Employee> GetEmployeeAsync(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await _dataContext.Employees.FindAsync(cancellationToken, id);
        }

        public async Task<int> InsertEmployeeAsync(Employee employee, CancellationToken cancellationToken = default(CancellationToken))
        {
            _dataContext.Employees.Add(employee);
            await _dataContext.SaveChangesAsync(cancellationToken);
            return employee.Id;
        }

    }
}