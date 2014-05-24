using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class CollegeList : System.Web.UI.Page
    {
        Eva.BLL.College bll = new BLL.College();
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.Model.College college = new Model.College();
        Eva.Model.Major major = new Model.Major();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                Bing();
            }
        }
        private void Bing()
        {
            var set = bll.GetAllList();
            CollegeRepeater.DataSource = set;
            CollegeRepeater.DataBind();
        }

        protected void CollegeRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditCollege.aspx?id=" + id);
            }
            if (e.CommandName == "delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (bll.Delete(id))
                {
                    Bing();
                    Maticsoft.Common.MessageBox.Show(this, "删除成功！");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除失败！");
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddCollege.aspx");
        }
    }
}