using CrudTwoTablesWebApi_Feb13.Interfaces;
using CrudTwoTablesWebApi_Feb13.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudTwoTablesWebApi_Feb13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourse _course;

        public CourseController(ICourse course)
        {
            _course = course;
        }

        [HttpGet]
        public List<Tcourse1> getAllCourses()
        {
            return _course.getAllCourses();
           
        }

        [HttpPost]
        public List<Tcourse1> addNew(Tcourse1 course)
        {
            return _course.AddNewCourse(course);
        }

       
        [HttpPut]
        public string updateCourse(Tcourse1 course)
        {
            return _course.updateCourse(course);
        }

        [HttpDelete("{CourseId}")]
        public string deleteCourse(int id)
        {
            return _course.DeleteCourse(id);
        }

    }
}
