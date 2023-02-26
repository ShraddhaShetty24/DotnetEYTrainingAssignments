using CrudTwoTablesWebApi_Feb13.Interfaces;
using CrudTwoTablesWebApi_Feb13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudTwoTablesWebApi_Feb13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IStudent _student;

        public StudentController(IStudent student)
        {
            _student= student;
        }


        [HttpGet]
        public List<StudentInfo> getAllStudents()
        {

            return _student.getAllStudents();


            //}
            //[HttpPost]
            //public List<Tstudent1> AddStudent(Tstudent1 student)
            //{

            //    return _student.AddNewStudent(student);
            //}



            //[HttpDelete("{StudentId}")]
            //public string DeleteStudent(int id)
            //{
            //    return _student.DeleteStudent(id);
            //}

            //[HttpPut]
            //public string editStudent(Tstudent1 student)
            //{

            //    return _student.updateStudent(student);
            //}

        }
    }
}
