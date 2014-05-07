using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Teacher
{
    public partial class Evaluation : System.Web.UI.Page
    {
        BLL.Item item = BLL.BLLFactory.GetItemBLLInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int id = Convert.ToInt32(Request["id"]);
                studentId.Value = "2";
                ItemRepeater.DataSource = item.GetAllList();
                ItemRepeater.DataBind();
            }
        }
    }
}