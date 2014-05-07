using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Teacher
{
    public partial class ScoreList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Eva.BLL.Mark markBll = new BLL.Mark();
                int id = int.Parse(Request["id"]);
                var set = markBll.GetListByStudentId(id);
                MarkRepeater.DataSource = set;
                MarkRepeater.DataBind();


                Eva.BLL.WebUser blluser=new BLL.WebUser();
                Eva.Model.WebUser user=new Model.WebUser();
                user=blluser.GetModel(id);
                Label1.Text = user.Name;
            }
        }
    }
}