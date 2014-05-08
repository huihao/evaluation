using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Evaluation
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Eva.BLL.WebUser ww = new Eva.BLL.WebUser();
            Session["user"] = ww.GetModel(1);
            Response.Redirect("Teacher/ApplyList.aspx");
        }
    }
}