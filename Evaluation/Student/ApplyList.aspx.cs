using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class ApplyList : System.Web.UI.Page
    {
        Eva.BLL.Mark bllMark = new BLL.Mark();
        Eva.Model.WebUser user = new Model.WebUser();
        Eva.Model.Mark mark = new Model.Mark();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                user = Session["user"] as Model.WebUser;
                var set = bllMark.getListByStuCheckStep(Convert.ToInt16(user.StudentId));
                MarkRepeater.DataSource = set;
                MarkRepeater.DataBind();
            }
        }

        protected void MarkRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                Response.Redirect("EditApply.aspx?id=" + id);

            }
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                mark = bllMark.GetModel(id);
                mark.BonusPoint = null;
                mark.CheckStep = 0;
                mark.Reason = null;
                if (bllMark.Update(mark))
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                    return;
                }
                else 
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除失败！");
                }


            }
        }
    }
}