using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8
{
    public class CoopStudent : Student
    {
        public static int MaxWeeklyHours;
        public static int MaxNumOfCourses;

        public CoopStudent(string name) : base(name)
        {
            
        }

        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
            foreach (Course course in selectedCourses)
            {
                hours += course.WeeklyHours;
            }

            if (hours > MaxWeeklyHours)
            {
                throw new Exception("You selection exceeds the maximum weekly hours: " + MaxWeeklyHours.ToString());
            }

            if (selectedCourses.Count > MaxNumOfCourses)
            {
                throw new Exception("You selection exceeds the maximum amount of courses: " + MaxNumOfCourses.ToString());
            }

            base.RegisterCourses(selectedCourses);
        }

        public override string ToString()
        {
            string textForm = base.Id.ToString() + " - " + base.Name + " (Co-op)";
            return textForm;
        }
    }
}