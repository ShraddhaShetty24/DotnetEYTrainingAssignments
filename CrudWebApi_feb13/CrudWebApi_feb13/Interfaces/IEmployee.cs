using CrudWebApi_feb13.Models;

namespace CrudWebApi_feb13.Interfaces
{
    public interface IEmployee
    {

        //definitions only--method definitions

        //Method definition for create operation
        List<TEmployee> addEmployee(TEmployee employee);
        TEmployee getEmployeeById(int id);

        List<TEmployee> allEmployees();

        string deleteEmployee(int id);

        List<TEmployee> updateEmployee(TEmployee employee);

       

        //bool deleteStudent(int id);

    }
}
