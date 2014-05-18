using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class ClassList : System.Web.UI.Page
    {
        Eva.BLL.Class bllClass = new BLL.Class();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var set = bllClass.GetAllListWithCollegeId();
                ClassRepeater.DataSource = set;
                ClassRepeater.DataBind();

            }
        }

        protected void ClassRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="update")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                Response.Redirect("EditClass.aspx?id=" + id);
            }
            if (e.CommandName=="delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                if (bllClass.Delete(id))
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除失败！");
                }
            }

        }
    }
}