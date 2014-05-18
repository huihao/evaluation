using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class MajorList : System.Web.UI.Page
    {
        Eva.BLL.Major bll = new BLL.Major();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                var set = bll.GetAllList();
                MajorRepeater.DataSource = set;
                MajorRepeater.DataBind();
            }
        }

        protected void MajorRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="update")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                Response.Redirect("EditMajor.aspx?id=" + id);
            }
            if (e.CommandName=="delete")
            {
                int id = Convert.ToInt16(e.CommandArgument);
                if (bll.Delete(id))
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除成功!");
                }
                else
                {
                    Maticsoft.Common.MessageBox.Show(this, "删除失败！");
                }
            }
        }
    }
}