using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddItem : System.Web.UI.Page
    {
        Model.Item item = new Model.Item();
        BLL.Item bll = new BLL.Item();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtName.Text.Trim().Length==0)
            {
                strErr += "评价指标不能为空！\\n";
            }
            if (txtValue.Text.Trim().Length==0)
            {
                strErr += "分值不能为空！\\n";
            }
            if (strErr!="")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
            }
            item.Name = txtName.Text;
            item.Value =decimal.Parse(txtValue.Text);
            if (bll.Add(item) != 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "ItemList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "添加失败！");
            }
        }
    }
}