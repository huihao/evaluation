using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class EditClass : System.Web.UI.Page
    {
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.BLL.Class bllClass = new BLL.Class();
        Eva.Model.Class classes = new Model.Class();
        Eva.Model.Major major = new Model.Major();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var CollegeDS = bllCollege.GetAllList();
                int id = int.Parse(Request["id"]);
                classes = bllClass.GetModel(id);
                major = bllMajor.GetModel(Convert.ToInt16(classes.MajorId));

                CollegeList.DataSource = CollegeDS.Tables["ds"].DefaultView;
                CollegeList.DataTextField = "Name";
                CollegeList.DataValueField = "Id";
                CollegeList.DataBind();

                CollegeList.Items.FindByValue(major.CollegeId.ToString()).Selected = true;
                LoadMajor();


                MajorList.Items.FindByValue(classes.MajorId.ToString()).Selected = true;
                txtClass.Text = classes.Name;


            }

        }
        private void LoadMajor()
        {
            MajorList.Items.Clear();
            var MajorDS = bllMajor.GetAllList();
            MajorList.DataSource = MajorDS.Tables["ds"].DefaultView;
            MajorList.DataTextField = "Name";
            MajorList.DataValueField = "Id";
            MajorList.DataBind();

        }

        protected void CollegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMajor();

        }



        protected void btnSave_Click(object sender, EventArgs e)
        {

            string strErr = "";
            if (CollegeList.SelectedValue=="0")
            {
                strErr += "请选择学院！";
            }
            if (MajorList.SelectedValue=="0")
            {
                strErr += "请选择专业";
            }
            if (txtClass.Text.Trim().Length==0)
            {
                strErr += "班级不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            
            int id = int.Parse(Request["id"]);
            classes = bllClass.GetModel(id);
            classes.Name = txtClass.Text;
            classes.MajorId = int.Parse(MajorList.SelectedValue);
            if (bllClass.Update(classes))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "修改成功！", "ClassList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "修改失败！");
            }
        }
    }
}