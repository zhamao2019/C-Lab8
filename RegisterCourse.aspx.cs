using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                List<Student> studentsList = Session["studentSession"] as List<Student>;
                drpStuName.Items.Add(new ListItem("Please select a student", ""));

                // initialized the student DropDownList from session
                foreach(Student student in studentsList)
                {
                    drpStuName.Items.Add(new ListItem (student.ToString(), student.Id.ToString()));
                }

                // initialize and display the available courses
                List<Course> courses = Helper.GetAvailableCourses();
                foreach (Course course in courses)
                {
                    cblCourses.Items.Add(new ListItem (course.Code + " " + course.Title + " - " + course.WeeklyHours + " hours per week", course.Code));
                }

            }
        }

        protected void drpStudent_SelectedChanged(object sender, EventArgs e)
        {

            foreach(ListItem item in cblCourses.Items)
            {
                item.Selected = false;
            }
            if (drpStuName.SelectedValue != "")
            {
                List<Student> studentsList = (List<Student>)Session["studentSession"];
                Student selectedStudent = studentsList[drpStuName.SelectedIndex - 1];
                lbMessage.Text = "selected" + selectedStudent.RegisteredCourses.Count.ToString() + " " + selectedStudent.TotalWeeklyHours().ToString() + " hours weekly";
            }
        }
        protected void btnClickSave(object sender, EventArgs e)
        {
            lbError.Visible = false;

            if (!Page.IsValid)
            {
                return;
            }
            else
            {
                
                try
                {
                    List<Student> studentsList = (List<Student>)Session["studentSession"];
                    Student selectedStudent = studentsList[drpStuName.SelectedIndex - 1];
                    List<Course> selectedCourseList = new List<Course>();

                    // get a list for the selected courses of this student
                    for (int i = 0; i < cblCourses.Items.Count; i++)
                    {
                        if (cblCourses.Items[i].Selected == true)
                        {
                            Course selectedCourse = Helper.GetCourseByCode(cblCourses.Items[i].Value);
                            selectedCourseList.Add(selectedCourse);

                        }
                    }

                    // validation of none selected
                    if (selectedCourseList.Count == 0)
                    {
                        throw new Exception("You need select at least one course");
                    }

                    selectedStudent.RegisterCourses(selectedCourseList);
                    lbMessage.Text = $"Selected student has registered {selectedStudent.RegisteredCourses.Count.ToString()} courses, {selectedStudent.TotalWeeklyHours().ToString()} hours weekly";
                    
                }
                catch (Exception ex)
                {
                    lbError.Visible = true;
                    lbError.Text = ex.Message;   
                }
            }
        }
    }
}