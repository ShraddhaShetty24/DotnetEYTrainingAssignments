using CrudTwoTablesWebApi_Feb13.Interfaces;
using CrudTwoTablesWebApi_Feb13.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudTwoTablesWebApi_Feb13.Repository
{
    public class CourseRepository : ICourse
    {

        private readonly StudentCourse2Context _studentCourse2Context;

        public CourseRepository(StudentCourse2Context studentCourse2Context)
        {
           _studentCourse2Context= studentCourse2Context;
        }

        public List<Tcourse1> AddNewCourse(Tcourse1 course)
        {
            _studentCourse2Context.Tcourse1s.Add(course);
            _studentCourse2Context.SaveChanges();
            return _studentCourse2Context.Tcourse1s.ToList();
        }

        public string DeleteCourse(int id)
        {
            try
            {
                var currentCourse = _studentCourse2Context.Tcourse1s.Find(id);
                if (currentCourse != null)
                {

                    _studentCourse2Context.Tcourse1s.Remove(currentCourse);
                    _studentCourse2Context.SaveChanges();
                    return "deleted successfully";

                }
                return "Not Found";

            }
            catch (Exception entityException)
            {

                return entityException.Message;
            }


        }

        public List<Tcourse1> getAllCourses()
        {
            return _studentCourse2Context.Tcourse1s.ToList();
            
           //return _studentCourse2Context.Tcourse1s.Include(s => s.Tstudent1s).ToList();
        }

        public string updateCourse(Tcourse1 course)
        {
            var currentCourse = _studentCourse2Context.Tcourse1s.Find(course.CourseId);
            if (currentCourse != null)
            {
                currentCourse.CourseName = course.CourseName;
                currentCourse.CourseFee= course.CourseFee;
                _studentCourse2Context.SaveChanges();
                return "updated successfully";
            }
            return "Not found";
        }
    }
    }

