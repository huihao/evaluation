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
                ItemRepeater.DataSource = item.GetAllList();
                ItemRepeater.DataBind();
            }
        }
    }
}