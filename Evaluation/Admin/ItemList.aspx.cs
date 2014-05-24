using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class ItemList : System.Web.UI.Page
    {
        Eva.BLL.Item bll = new BLL.Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ItemRepeaBind();
            }
        }
        public void ItemRepeaBind()
        {
            var set = bll.GetAllList();
            ItemRepeater.DataSource = set;
            ItemRepeater.DataBind();
        }


        protected void ItemRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName=="update")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("EditItem.aspx?id="+id);

            }
            if (e.CommandName=="delete")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (bll.Delete(id))
                {
                    ItemRepeaBind();
                    Maticsoft.Common.MessageBox.Show(this, "修改成功！");
                    
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddItem.aspx");
        }
    }
}