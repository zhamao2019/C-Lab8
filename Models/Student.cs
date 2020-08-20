using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace lab8
{
    public class Student
    {
        //private int id;
        public int Id { get; }
        public string Name { get; }

        // method refill the registered courses by selected courses
        public List<Course> RegisteredCourses { get; }
        public Student(string name)
        {
            this.Name = name;

            // create a random 6 digital number for Id
            Random idNum = new Random();
            int id = idNum.Next(100000, 699999);
            this.Id = id;
            RegisteredCourses = new List<Course>();
        }

        public virtual void RegisterCourses(List<Course> selectedCourses)
        {
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);

        }

        // method calculated total hours of all registered courses by the student
        public int TotalWeeklyHours()
        {
            int totalWeeklyHours = 0;

            for(int i = 0; i < RegisteredCourses.Count; i++)
            {
                totalWeeklyHours += RegisteredCourses[i].WeeklyHours;
            }

            return totalWeeklyHours;
        }

       
    }
}
