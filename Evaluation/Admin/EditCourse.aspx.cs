using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditCourse : System.Web.UI.Page
    {
        Eva.BLL.Course bll = new BLL.Course();
        Eva.Model.Course course = new Model.Course();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);
                course = bll.GetModel(id);
                txtGpa.Text = course.Gpa.ToString();
                txtName.Text = course.Name;
                txtIntr.Text = course.Introdution;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtName.Text.Trim().Length == 0)
            {
                strErr += "课程名不能为空\\n";
            }
            if (txtGpa.Text.Trim().Length == 0)
            {
                strErr += "学分不能为空！\\n";
            }
            if (txtIntr.Text.Trim().Length == 0)
            {
                strErr += "课程介绍不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            int id = int.Parse(Request["id"]);
            course.Id = id;
            course.Name = txtName.Text;
            course.Gpa = Convert.ToDecimal(txtGpa.Text);
            course.Introdution = txtIntr.Text;
            if (bll.Update(course))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "CourseList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }
        }
    }
}