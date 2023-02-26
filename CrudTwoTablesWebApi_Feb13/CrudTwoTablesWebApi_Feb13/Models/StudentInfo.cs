namespace CrudTwoTablesWebApi_Feb13.Models
{
    public class StudentInfo
    {
        public int StudentId { get; set; } 
        public string StudentName { get; set; }

        public string StudentAddress { get; set; }

        public int courseId { get; set; }
        public string courseName { get; set; }

        public int courseFee { get; set; }
       
       
    }
}
