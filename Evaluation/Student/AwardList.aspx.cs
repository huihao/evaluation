using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class AwardList : System.Web.UI.Page
    {
        BLL.Awards bll = new BLL.Awards();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDate();
                AwardBing();
            }
        }
        protected void AwardBing()
        {
            Eva.Model.WebUser student = Session["user"] as Eva.Model.WebUser;
            Label1.Text = student.Name;
            int id = Convert.ToInt32(student.StudentId);

            var set = bll.GetListByStudentId(id, YearList.SelectedItem.Text, Termlist.SelectedItem.Text);
            AwardRepeater.DataSource = set;
            AwardRepeater.DataBind();
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

        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            AwardBing();
        }

        protected void Termlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            AwardBing();
        }

     

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddAward.aspx");
        }
    }
}