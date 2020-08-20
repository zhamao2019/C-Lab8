using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8
{
    public class ParttimeStudent : Student
    {
        public static int MaxNumOfCourses;

        public ParttimeStudent(string name) : base(name)
        {

        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("You selection exceeds the maximum amount of courses: " + MaxNumOfCourses.ToString());
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            string textForm = base.Id.ToString() + " - " + base.Name + " (Part Time)";
            return textForm;
        }
    }
}