using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class EditApply : System.Web.UI.Page
    {
        Eva.BLL.Mark bll = new BLL.Mark();
        Eva.Model.Mark mark = new Model.Mark();
        Eva.BLL.Course bllCourse = new BLL.Course();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Request["id"]);
                mark = bll.GetModel(id);
                txtCourseName.Text = bllCourse.GetModel(Convert.ToInt16(mark.CourseId)).Name;
                txtBonusPoint.Text = mark.BonusPoint.ToString();
                txtScore.Text = mark.Score.ToString();

            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtBonusPoint.Text.Trim().Length == 0)
            {
                strErr += "加分不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }

            int id = int.Parse(Request["id"]);
            mark = bll.GetModel(id);

            mark.BonusPoint = Convert.ToDecimal(txtBonusPoint.Text);
            if (bll.Update(mark))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "ApplyList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }



        }
    }
}