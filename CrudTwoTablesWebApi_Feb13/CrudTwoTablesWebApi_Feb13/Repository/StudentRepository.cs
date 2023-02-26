using CrudTwoTablesWebApi_Feb13.Interfaces;
using CrudTwoTablesWebApi_Feb13.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudTwoTablesWebApi_Feb13.Repository
{
    public class StudentRepository : IStudent
    {
        private readonly StudentCourse2Context _studentCourse2Context;

        public StudentRepository(StudentCourse2Context studentCourse2Context)
        {
            _studentCourse2Context= studentCourse2Context;
        }

        //public List<Tstudent1> AddNewStudent(Tstudent1 student)
        //{
        //    _studentCourse2Context.Tstudent1s.Add(student);
        //    _studentCourse2Context.SaveChanges();
        //    return _studentCourse2Context.Tstudent1s.ToList();
        //}

        //public string DeleteStudent(int id)
        //{
        //    var currentStudent = _studentCourse2Context.Tstudent1s.Find(id);
        //    _studentCourse2Context.Tstudent1s.Remove(currentStudent);
        //    _studentCourse2Context.SaveChanges();
        //    return "Deletd Successfully";
        //}

        public List<StudentInfo> getAllStudents()
        {
            // return _studentCourse2Context.Tstudent1s.ToList();
            //return _studentCourse2Context.Tstudent1s.Include(x => x.Course).ToList();
            var studentList = (from st in _studentCourse2Context.Tstudent1s
                               join course in _studentCourse2Context.Tcourse1s on st.CourseId equals course.CourseId
                               select new StudentInfo()
                               {
                                   StudentId = st.StudentId,
                                   StudentName = st.StudentName,
                                   StudentAddress = st.StudentAddress,
                                   courseId = course.CourseId,
                                   courseName = course.CourseName,
                                   courseFee = course.CourseFee
                               }).ToList();
            return studentList;
        }

       

        //public string updateStudent(Tstudent1 student)
        //{
        //    var currentStudent = _studentCourse2Context.Tstudent1s.Find(student.StudentId);
        //    if (currentStudent != null)
        //    {
        //        currentStudent.StudentName = student.StudentName;
               
        //        currentStudent.CourseId = student.CourseId;
        //        currentStudent.Course = student.Course;
        //        _studentCourse2Context.SaveChanges();
                
        //    }
        //    return "Updated";
        //}

       
    }
}
