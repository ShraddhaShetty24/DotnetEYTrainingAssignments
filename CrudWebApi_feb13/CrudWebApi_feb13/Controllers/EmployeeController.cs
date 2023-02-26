using CrudWebApi_feb13.Interfaces;
using CrudWebApi_feb13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace CrudWebApi_feb13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        //[HttpPost]
        //public List<TEmployee> GetEmployees(TEmployee employee)
        //{
        //    return _employee.addEmployee(employee);
        //}

        [HttpGet("{id:int}")]
        public TEmployee employeeById(int id)
        {
            return _employee.getEmployeeById(id);
        }

        [HttpPost]
        public List<TEmployee> addEmployee(TEmployee employee)
        {
            return _employee.addEmployee(employee);        

        }

        [HttpGet]
        public List<TEmployee> getAllEmployees()
        {
            return _employee.allEmployees();
        }

        [HttpDelete("{EmployeeId}")]
        public string deleteEmployees(int id)
        {
            //_employee.deleteEmployee(id);
            //return "Successfully deleted";
            var result = _employee.deleteEmployee(id);
            return result;
        }

        [HttpPut]
        public List<TEmployee> updateEmployee(TEmployee employee)
        {
            return _employee.updateEmployee(employee);
        }
        //[HttpDelete("{id:int}")]
        //public string deleteStudent(int id)
        //{

        //    return "Deleted Successfully";
        //}

    }
}
