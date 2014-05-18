using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditMajor : System.Web.UI.Page
    {
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.Model.Major major = new Model.Major();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);
                var dsMa = bllMajor.GetAllList();
                var dsCo = bllCollege.GetAllList();

                major = bllMajor.GetModel(id);

                CollegeList.DataSource = dsCo.Tables["ds"].DefaultView;
                CollegeList.DataTextField = "Name";
                CollegeList.DataValueField = "Id";
                CollegeList.DataBind();
                
                CollegeList.Items.FindByValue(major.CollegeId.ToString()).Selected = true;
                txtMajor.Text = major.Name;


            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (CollegeList.SelectedValue=="0")
            {
                strErr += "请选择学院！";
            }
            if (txtMajor.Text.Trim().Length==0)
            {
                strErr += "专业不能为空！";
            }
            if (strErr!="")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            int id = int.Parse(Request["id"]);
            major=bllMajor.GetModel(id);
            major.CollegeId = int.Parse(CollegeList.SelectedValue);
            major.Name = txtMajor.Text;
            if (bllMajor.Update(major))
            {
                Maticsoft.Common.MessageBox.Show(this, "修改成功！");
            }
            else {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }
        }
    }
}