using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditAuth1 : System.Web.UI.Page
    {
        Eva.BLL.Authority blllAuth = new BLL.Authority();
        Eva.BLL.WebUser bllUser = new BLL.WebUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var set = blllAuth.GetAllList();
                AuthList.DataSource = set.Tables["ds"].DefaultView;
                AuthList.DataTextField = "Name";
                AuthList.DataValueField = "Id";
                AuthList.DataBind();
                AuthList.Items.Insert(0, new ListItem("请选择", "0"));
                int id = int.Parse(Request["id"]);
                txtName.Text = bllUser.GetModel(id).Name;

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (AuthList.SelectedValue == "0")
            {
                strErr += "请选择权限！";

            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            int id = int.Parse(Request["id"]);
            Eva.Model.WebUser user = new Model.WebUser();
            user = bllUser.GetModel(id);
            user.AuthorityId = int.Parse(AuthList.SelectedValue);
            if (bllUser.Update(user))
            {
                Maticsoft.Common.MessageBox.Show(this, "修改成功！");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }
        }

    }
}