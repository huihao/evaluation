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

                var set = bllStudent.GetAllStudents();
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
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                }
            }
        }

        protected void btnAllDEL_Click(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in StudentRepeater.Items)
            {
                CheckBox chk = (CheckBox)item.FindControl("chkID");
                if (chk.Checked)
                {

                }
            }

        }

        protected void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked)
            {
                foreach (RepeaterItem item in StudentRepeater.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkID");
                    chk.Checked = true;
                }
            }
            else
            {
                foreach (RepeaterItem item in StudentRepeater.Items)
                {
                    CheckBox chk = (CheckBox)item.FindControl("chkID");
                    chk.Checked = false;
                }
            }
        }
    }
}