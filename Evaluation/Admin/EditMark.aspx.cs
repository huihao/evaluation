using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditMark : System.Web.UI.Page
    {
        Model.Mark mark = new Model.Mark();
        BLL.Mark bll = new BLL.Mark();
        BLL.Course bllCourse = new BLL.Course();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDate();
                int id = int.Parse(Request["Id"]);
                mark = bll.GetModel(id);
                YearList.Items.FindByValue(mark.AcademicYear.ToString()).Selected = true;
                Termlist.Items.FindByValue(mark.SchoolTerm.ToString()).Selected = true;
                CourseList.DataSource = bllCourse.GetAllList();
                CourseList.DataBind();
                CourseList.Items.FindByValue(mark.CourseId.ToString()).Selected = true;
                txtSroce.Text = mark.Score.ToString();

            }
        }

        private void SetDate()
        {
            for (int i = DateTime.Now.Year - 8; i <= DateTime.Now.Year; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";

            if (txtSroce.Text.Trim().Length == 0)
            {
                strErr += "成绩不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);

            }
            int id = int.Parse(Request["Id"]);
            mark = bll.GetModel(id);
            mark.AcademicYear = int.Parse(YearList.SelectedValue);
            mark.SchoolTerm = int.Parse(Termlist.SelectedValue);
            mark.CourseId = int.Parse(CourseList.SelectedValue);
            mark.Score = decimal.Parse(txtSroce.Text);
            mark.Gpa = BLL.Utils.GetGpa(Convert.ToInt16(mark.Score));
            if (bll.Update(mark))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功", "ShowMark.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败");
            }



        }
    }
}