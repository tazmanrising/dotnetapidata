using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnetapi.Data.Models
{
    public class Repository
    {
        public List<Course> GetCourses()
        {
            return new List<Course> {
                            new Course () {  CourseId = 1, CourseName = "Chemistry"},
                            new Course () {  CourseId = 2, CourseName = "Physics"},
                            new Course () {  CourseId = 3, CourseName = "Math" },
                            new Course () {  CourseId = 4, CourseName = "Computer Science" }
            };
        }


        public List<tblTips> GetTips()
        {
            return new List<tblTips>
            {
                new tblTips () { body = "this is a news test" }
            };
        }


        public List<tblComments> GetComments()
        {
            return new List<tblComments>
            {
                new tblComments () { id = 1, tblTipsId = 1, created = DateTime.Now, createdby = "tom", Comments = "this is a news test" }
            };
        }



    }




    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

}
