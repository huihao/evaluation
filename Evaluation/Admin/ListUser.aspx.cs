using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eva.BLL;

namespace Eva.Evaluation.Admin
{
    public partial class ListUser : System.Web.UI.Page
    {
        BLL.WebUser userBll = BLLFactory.GetWebUserBLLInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UserRepeater.DataSource = userBll.GetAllList();
                UserRepeater.DataBind();
            }
        }

        protected void UserRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}