using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //lbErrorStuName.Visible = false;
            //lbErrorStuType.Visible = false;

            if (this.IsPostBack == false)
            {
                stuType.Items.Add(new ListItem("Please Select Type", ""));
                stuType.Items.Add(new ListItem("Full Time", "fullTime"));
                stuType.Items.Add(new ListItem("Part Time", "partTime"));
                stuType.Items.Add(new ListItem("Co-op", "coop"));
            }
            
            if (Session["studentSession"] == null)
            {
                // create a session to store selections
                List<Student> studentsList = new List<Student>();
                Session["studentSession"] = studentsList;

                //create the default table
                DisplayStudent(studentsList);
            }
            else
            {
                
                // retrieve data from session
                var studentsList = (List<Student>)Session["studentSession"];
                DisplayStudent(studentsList);
                
            }
        }

        protected void ClickAdd(object sender, EventArgs e)
        {
            // retrieve data from session
            var studentsList = Session["studentSession"] as List<Student>;

            if (!Page.IsValid) 
            {
                DisplayStudent(studentsList);
                return; 
            }
            else
            {
                // create an instance base on student type 
                if (stuType.SelectedValue == "fullTime")
                {
                    FulltimeStudent student = new FulltimeStudent(stuName.Text);
                    studentsList.Add(student);
                }
                else if (stuType.SelectedValue == "partTime")
                {
                    ParttimeStudent student = new ParttimeStudent(stuName.Text);
                    studentsList.Add(student);
                }
                else if (stuType.SelectedValue == "coop")
                {
                    CoopStudent student = new CoopStudent(stuName.Text);
                    studentsList.Add(student);
                }

                stuName.Text = "";
                stuType.SelectedValue = "";

                DisplayStudent(studentsList);
            }
        }

        private void DisplayStudent(List<Student> studentsList)
        {
            if (studentsList.Count == 0)
            {
                TableRow row = new TableRow();
                stuTable.Rows.Add(row);

                TableCell cell = new TableCell();
                row.Cells.Add(cell);
                Label cellText = new Label();
                cellText.Text = "No student selected";
                cell.Controls.Add(cellText);

                cellText.CssClass = "error";
                cell.ColumnSpan = 2;
                row.HorizontalAlign = HorizontalAlign.Center;
                
            }   
            else
            {
                // remove all the rows in the table except the first header row
                if (stuTable.Rows.Count > 1)
                {
                    // remove rows from bottom to the top
                    for (int i = stuTable.Rows.Count - 1; i > 0; i--)
                    {
                        stuTable.Rows.RemoveAt(i);
                    }
                }

                // create table and display data 
                for (int i = 0; i < studentsList.Count; i++)
                {
                    TableRow row = new TableRow();

                    TableCell cell = new TableCell();
                    cell.Text = studentsList[i].Id.ToString();
                    row.Cells.Add(cell);

                    cell = new TableCell();
                    cell.Text = studentsList[i].Name;
                    row.Cells.Add(cell);

                    stuTable.Rows.Add(row);
                   
                }
            }
        }
        
    }
}