using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddMajor : System.Web.UI.Page
    {
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.Model.Major major = new Model.Major();
        Eva.BLL.Major bllMajor = new BLL.Major();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var set = bllCollege.GetAllList();
                CollegeList.DataSource = set.Tables["ds"].DefaultView; ;
                CollegeList.DataTextField = "Name";
                CollegeList.DataValueField = "Id";
                CollegeList.DataBind();
                CollegeList.Items.Insert(0, new ListItem("请选择", "0"));
            }

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (CollegeList.SelectedIndex == 0)
            {
                strErr += "请选择学院！";
            }
            if (txtMajor.Text.Trim().Length == 0)
            {
                strErr += "专业不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            major.CollegeId = Convert.ToInt16(CollegeList.SelectedValue);
            major.Name = txtMajor.Text;
            if (bllMajor.Add(major) != 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "添加成功！");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "添加失败！");
            }
        }
    }
}