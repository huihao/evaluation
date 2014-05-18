using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{

    public partial class EditCollege : System.Web.UI.Page
    {
        Eva.BLL.College bll = new BLL.College();
        Eva.Model.College college = new Model.College();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);
                college = bll.GetModel(id);
                txtName.Text = college.Name;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtName.Text.Trim().Length == 0)
            {
                strErr += "学院不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            int id = int.Parse(Request["id"]);
            college.Id = id;
            college.Name = txtName.Text;
            if (bll.Update(college))
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