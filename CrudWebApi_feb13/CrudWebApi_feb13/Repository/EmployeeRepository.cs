using CrudWebApi_feb13.Interfaces;
using CrudWebApi_feb13.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudWebApi_feb13.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly EmployeeContext _employeeContext;

        public EmployeeRepository(EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
        }

        public List<TEmployee> addEmployee(TEmployee employee)
        {
            _employeeContext.TEmployees.Add(employee);
            _employeeContext.SaveChanges();
            return _employeeContext.TEmployees.ToList();
        }

        public List<TEmployee> allEmployees()
        {
            return _employeeContext.TEmployees.ToList();
        }

        public string deleteEmployee(int id)
        {
            var deleteobj= _employeeContext.TEmployees.Remove(getEmployeeById(id));
            _employeeContext.SaveChanges();
            return "deleted";
        }

        //public bool deleteStudent(int id)
        //{
        //    bool result = false;
        //    var employee = _employeeContext.TEmployees.Find(id);
        //    if (employee != null)
        //    {
        //        //_employeeContext.Entry(employee).State = EntityState.Deleted;
        //        _employeeContext.SaveChanges();
        //        result = true;
        //    }
        //    else
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        public TEmployee getEmployeeById(int id)
        {
            TEmployee employee = _employeeContext.TEmployees.Find(id);
            //_employeeContext.TEmployees.Find(id);
            return  employee ;
        }

        public List<TEmployee> updateEmployee(TEmployee employee)
        {
            var updateInfo = _employeeContext.TEmployees.Find(employee.EmployeeId);
           
            updateInfo.EmployeeName = employee.EmployeeName;
           
            updateInfo.EmployeeSalary=employee.EmployeeSalary;
            updateInfo.EmployeeAge  = employee.EmployeeAge;

           
            _employeeContext.SaveChanges();
            return _employeeContext.TEmployees.ToList();
        }



        //public string insertEmployee(TEmployee employee)
        //{
        //    var eachEmployee = new TEmployee()
        //    {
        //        EmployeeId = employee.EmployeeId,
        //        EmployeeName = employee.EmployeeName,
        //        EmployeeAge= employee.EmployeeAge,
        //        EmployeeSalary=employee.EmployeeSalary

        //    };
        //    _employeeContext.TEmployees.Add(eachEmployee);
        //    _employeeContext.SaveChanges();

        //    return "Record Inserted";
        //}
    }
}
