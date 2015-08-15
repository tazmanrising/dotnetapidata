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


    }


    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
    }

}
