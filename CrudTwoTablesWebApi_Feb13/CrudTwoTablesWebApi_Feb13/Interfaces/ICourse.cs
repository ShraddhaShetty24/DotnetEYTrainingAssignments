using CrudTwoTablesWebApi_Feb13.Models;

namespace CrudTwoTablesWebApi_Feb13.Interfaces
{
    public interface ICourse
    {
        List<Tcourse1> getAllCourses();
        List<Tcourse1> AddNewCourse(Tcourse1 course);

        String updateCourse(Tcourse1 course);

        String DeleteCourse(int id);

    }
}
