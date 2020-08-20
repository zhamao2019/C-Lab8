using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace lab7
{
    public partial class AddStudent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack == false)
            {
                stuType.Items.Add(new ListItem("Please Select Type", "select"));
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
                Label NoData = new Label();
                NoData.CssClass = "error";
                TableRow row = new TableRow();
                stuTable.Controls.Add(row);
                TableCell cell = new TableCell();
                NoData.Text = "No student selected";
                cell.Controls.Add(NoData);
                cell.ColumnSpan = 2;
                row.HorizontalAlign = HorizontalAlign.Center;
                row.Controls.Add(cell);

            }
            else
            {
                // retrieve data from session
                var studentsList = (List<Student>)Session["studentSession"];
                
                // create table and display data 
                for (int i = 0; i < studentsList.Count; i++)
                {
                    TableRow row = new TableRow();
                    stuTable.Controls.Add(row);
                    Label Id = new Label();
                    Label Name = new Label();

                    for (int j = 0; j < 2; j++)
                    {
                        TableCell cell = new TableCell();
                        Id.Text = studentsList[i].Id.ToString();
                        Name.Text = studentsList[i].Name;
                        if (j == 0)
                        {
                            cell.Controls.Add(Id);
                        }
                        else
                        {
                            cell.Controls.Add(Name);
                        }
                        row.Controls.Add(cell);
                    }
                }    
            }
        }

        protected void ClickAdd(object sender, EventArgs e)
        {
            string typeId = stuType.SelectedValue;
            string studentName = stuName.Text;

            // retrieve data from session
            var studentsList = Session["studentSession"] as List<Student>;
           
            // create an instance base on student type 
            if (typeId == "fullTime")
            {
                FulltimeStudent student = new FulltimeStudent(studentName);
                studentsList.Add(student);
            }
            else if (typeId == "partTime")
            {
                ParttimeStudent student = new ParttimeStudent(studentName);
                studentsList.Add(student);
            }
            else if (typeId == "coop")
            {
                CoopStudent student = new CoopStudent(studentName);
                studentsList.Add(student);
            }
            
            // refresh the web page to clear the selection
            Response.Redirect(Request.RawUrl);
        }
        
    }
}