using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Master
{
    public partial class Teacher : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Eva.Model.WebUser user= Session["user"]as Eva.Model.WebUser;
                if (user != null)
                {
                    Label1.Text = user.Name;
                    
                }
            }
        }
    }
}