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
        BLL.Awards award = BLL.BLLFactory.GetAwardsBLLInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["id"]);
                studentId.Value = id.ToString();
                ItemRepeater.DataSource = item.GetAllList();
                ItemRepeater.DataBind();





            }
        }

        protected void ItemRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater ExplainRepeater = (Repeater)e.Item.FindControl("ExplainRepeater");
            


            ExplainRepeater.DataSource = award.GetList(" StudentId=" + studentId.Value);
            ExplainRepeater.DataBind();

        }


    }
}