using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace lab8
{
    public class Course
    {
        public string Code { get; }
        public string Title { get; }
        public int WeeklyHours;

        public Course(string code, string title)
        {
            Code = code;
            Title = title;
        }
        
    }
}