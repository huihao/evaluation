using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class ListStudent : System.Web.UI.Page
    {
        Eva.BLL.WebUser bllStudent = new BLL.WebUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bing();

            }
        }
        private void Bing()
        {
            var set = bllStudent.GetAllStudents();
            StudentRepeater.DataSource = set;
            StudentRepeater.DataBind();
        }

        protected void StudentRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "view")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("ShowMark.aspx?id=" + id);
            }

            if (e.CommandName == "update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditInfo.aspx?id=" + id);

            }
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (bllStudent.Delete(Convert.ToInt32(e.CommandArgument)))
                {
                    Bing();
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                }
            }
        }




    }
}