using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using FileView.Models;

namespace FileView.Repositories
{
    public interface IEmployee : IDisposable
    {
        Task<Employee> GetEmployeeAsync(int Id, CancellationToken cancellationToken = default(CancellationToken));
        Task<int> InsertEmployeeAsync(Employee employee, CancellationToken cancellationToken = default(CancellationToken));
        Task DeleteAllEmployeeAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
