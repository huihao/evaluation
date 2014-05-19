using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class ShowMark : System.Web.UI.Page
    {
        BLL.Mark markBll = BLL.BLLFactory.GetMarkBLLInstance();
        BLL.WebUser userBll = BLL.BLLFactory.GetWebUserBLLInstance();
        Model.WebUser user = new Model.WebUser();
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
            YearList.Items.Add(new ListItem("",""));
            for (int i = 1991; i < 2020; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(),i.ToString()));
            }

            Termlist.Items.Add(new ListItem("", ""));
            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void MarkBind()
        {
            //int id = int.Parse(Request["id"]);
            user = Session["user"] as Model.WebUser;
            var set = markBll.GetListByStudentId(Convert.ToInt16(user.StudentId), YearList.SelectedItem.Text, Termlist.SelectedItem.Text);
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
            if (e.CommandName=="update")
            {
                int id =Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditMark.aspx?id=" + id);
            }
            if (e.CommandName=="delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (markBll.Delete(id))
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                }
            }
        }
    }
}