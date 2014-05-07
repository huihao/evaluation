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
                if (!IsPostBack)
                {

                    MarkBind();
                }
            }
        }


        protected void MarkBind()
        {
            //int id = int.Parse(Request["id"]);
            var set = markBll.GetListByStudentId(1);
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
                Response.Redirect("MarkApply.aspx?id="+id);
            }

        }
    }
}