using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddClass : System.Web.UI.Page
    {
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.BLL.Class bllclass = new BLL.Class();
        Eva.Model.Class classes = new Model.Class();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCollegeList();
            }            
        }
        private void LoadCollegeList()
        {
            var set = bllCollege.GetAllList();

            CollegeList.DataSource = set.Tables["ds"].DefaultView;

            CollegeList.DataTextField = "Name";
            CollegeList.DataValueField = "Id";
            CollegeList.DataBind();
            CollegeList.Items.Insert(0, new ListItem("请选择", "0"));

        }
        private void LoadMajorList(int collegeId)
        {
            var set = bllMajor.GetList(" CollegeId =" + collegeId);
            MajorList.Items.Clear();            
            MajorList.DataSource = set.Tables["ds"].DefaultView;            
            MajorList.DataTextField = "Name";
            MajorList.DataValueField = "Id";
            MajorList.DataBind();
            CollegeList.Items.Insert(0, new ListItem("请选择", "0"));
          
        }



        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (int.Parse(CollegeList.SelectedValue) == 0)
            {
                strErr += "请选择学院！";
            }
            if (int.Parse(MajorList.SelectedValue) == 0)
            {
                strErr += "请选择专业！";
            }
            if (txtClass.Text.Trim().Length == 0)
            {
                strErr += "班级不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            classes.MajorId = int.Parse(MajorList.SelectedValue);
            classes.Name = txtClass.Text;
            if (bllclass.Add(classes) != 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "添加成功！");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "添加失败！");
            }


        }

        protected void CollegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMajorList(Convert.ToInt16(CollegeList.SelectedValue));
        }
    }
}