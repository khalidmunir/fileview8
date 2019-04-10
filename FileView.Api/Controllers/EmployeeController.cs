using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading;
using System.Threading.Tasks;
using FileView.Models;
using FileView.Repositories;

namespace FileView.Api.Controllers
{
    public class EmployeeController : ApiController
    {
        private readonly IEmployee _employeeManager;

        public EmployeeController(IEmployee employeeManager)
        {
            _employeeManager = employeeManager; 
        }


        // GET api/<controller>/5
        public async Task<IHttpActionResult> Get(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            var employee = await _employeeManager.GetEmployeeAsync(id, cancellationToken);

            if (employee == null)
                return NotFound();

            return Ok<Employee>(employee);
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]Employee employee, CancellationToken cancellationToken = default(CancellationToken))
        {
            try
            {
                var id = await _employeeManager.InsertEmployeeAsync(employee, cancellationToken);
                return Ok<int>(id);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}