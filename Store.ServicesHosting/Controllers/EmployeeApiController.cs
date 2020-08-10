using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Domain;
using Store.Services.Abstract;

namespace Store.ServicesHosting.Controllers
{
    [Route("api/employees")]
    [Produces("application/json")]
    public class EmployeeApiController : ControllerBase, IEmployeeService
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeApiController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost, ActionName("Post")]
        public Task<int> Add([FromBody]Employee employee)
        {
            return _employeeService.Add(employee);
        }

        [HttpDelete("{id}")]
        public Task Delete(int id)
        {
            return _employeeService.Delete(id);
        }

        [HttpPut, ActionName("Put")]
        public Task Edit([FromBody]Employee employee)
        {
            return _employeeService.Edit(employee);
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<Employee> GetAll()
        {
           return _employeeService.GetAll();
        }

        [HttpGet("{id}"), ActionName("Get")]
        public Task<Employee> GetById(int id)
        {
            return _employeeService.GetById(id);
        }
    }
}