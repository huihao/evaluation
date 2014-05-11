using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class ShowMark : System.Web.UI.Page
    {

        BLL.Mark markBll = BLL.BLLFactory.GetMarkBLLInstance();
        BLL.WebUser userBll = BLL.BLLFactory.GetWebUserBLLInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                SetDate();
                MarkBind();

            }
        }

        protected void SetDate()
        {
            YearList.Items.Add(new ListItem("", ""));
            for (int i = 1991; i < 2020; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            Termlist.Items.Add(new ListItem("", ""));
            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        protected void MarkBind()
        {
            Eva.Model.WebUser student = Session["user"] as Eva.Model.WebUser;
            Label1.Text = student.Name;
            int id = Convert.ToInt32(student.StudentId);

            var set = markBll.GetListByStudentId(id, YearList.SelectedItem.Text, Termlist.SelectedItem.Text);
            MarkRepeater.DataSource = set;
            MarkRepeater.DataBind();
        }

        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarkBind();
        }

        protected void Termlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            MarkBind();
        }

        protected void MarkRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "apply")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("MarkApply.aspx?id=" + id);
            }

        }
    }
}