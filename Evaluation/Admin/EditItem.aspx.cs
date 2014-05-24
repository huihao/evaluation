using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditItem : System.Web.UI.Page
    {
        BLL.Item bll = new BLL.Item();
        Model.Item item = new Model.Item();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);
                item = bll.GetModel(id);
                txtName.Text = item.Name;
                txtValue.Text = item.Value.ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtName.Text.Trim().Length==0)
            {
                strErr += "指标不能为空！\\n";
            }
            if (txtValue.Text.Trim().Length==0)
            {
                strErr += "分值不能为空！\\n";
            }
            if (strErr!="")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
            }
            int id = int.Parse(Request["id"]);
                item=bll.GetModel(id);
            item.Name=txtName.Text;
            item.Value=decimal.Parse( txtValue.Text);
            if (bll.Update(item))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功", "ItemList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }
        }
    }
}