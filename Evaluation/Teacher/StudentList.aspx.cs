using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Teacher
{
    public partial class StudentList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                Eva.BLL.WebUser bllStudent = new BLL.WebUser();
                Eva.Model.WebUser teacher = Session["user"] as Model.WebUser;

                var set = bllStudent.GetMyStudents(teacher.Id);
                StudentRepeater.DataSource = set;
                StudentRepeater.DataBind();
            }
        }
        protected void StudentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ScoreList.aspx?id=" + id);
            }
            if (e.CommandName == "eva")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("Evaluation.aspx?id=" + id);
            }

        }
    }
}