using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddCollege : System.Web.UI.Page
    {
        Eva.Model.College college = new Model.College();
        Eva.BLL.College bll = new BLL.College();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtCollege.Text.Trim().Length == 0)
            {
                strErr += "学院不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            college.Name = txtCollege.Text;
            if (bll.Add(college) != 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "添加成功！");
            }
            else {
                Maticsoft.Common.MessageBox.Show(this, "添加失败！");    
            }
        }
    }
}