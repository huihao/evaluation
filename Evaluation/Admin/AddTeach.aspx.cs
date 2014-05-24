using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddTeach : System.Web.UI.Page
    {
        Model.Teach teach = new Model.Teach();
        BLL.Teach bll = new BLL.Teach();
        BLL.WebUser bllTeacher = new BLL.WebUser();
        BLL.Course bllcourse = new BLL.Course();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTeacher();
                LoadCourse();
            }
        }
        private void LoadTeacher()
        {
            var set = bllTeacher.GetModelList(" AuthorityId=2");

            TeacherList.Items.Add(new ListItem("请选择", "0"));
            for (int i = 0; i < set.Count; i++)
            {
                TeacherList.Items.Add(new ListItem(set[i].Name, set[i].Id.ToString()));
            }
            TeacherList.DataBind();
        }
        private void LoadCourse()
        {
            var set = bllcourse.GetAllList();
            CourseList.DataSource = set.Tables["ds"].DefaultView;
            CourseList.DataTextField = "Name";
            CourseList.DataValueField = "Id";
            CourseList.DataBind();
            CourseList.Items.Insert(0, new ListItem("请选择", "0"));

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (TeacherList.SelectedValue == "0")
            {
                strErr += "请选择教师！\\n";
            }
            if (CourseList.SelectedValue == "0")
            {
                strErr += "请选择课程！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
            }


            teach.TeacherId = int.Parse(TeacherList.SelectedValue);
            teach.CourseId = int.Parse(CourseList.SelectedValue);
            if (bll.Add(teach) != 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功！", "TeachList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "添加失败！");
            }
        }
    }
}
