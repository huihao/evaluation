using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Eva.Evaluation.Teacher
{
    public partial class Info : System.Web.UI.Page
    {
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.BLL.WebUser bllUser = new BLL.WebUser();
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.Model.WebUser user = new Model.WebUser();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet ds = bllCollege.GetAllList();
                CollegeList.Items.Clear();
                CollegeList.DataSource = ds.Tables["ds"].DefaultView;

                CollegeList.DataTextField = "Name";
                CollegeList.DataValueField = "Id";
                CollegeList.DataBind();
                CollegeList.Items.Insert(0, new ListItem("请选择", "0"));

                int id = int.Parse(Request["id"]);
                user = bllUser.GetModel(id);
                txtName.Text = user.Name;
                txtIdCard.Text = user.IdCard;
                txtSex.Text = user.Sex;
                txtTel.Text = user.Phone;
                CollegeList.Items.FindByValue(user.CollegeId.ToString()).Selected = true;

                MajorList.Items.FindByValue(user.MajorId.ToString()).Selected = true;
                ClassList.Items.FindByValue(user.ClassId.ToString()).Selected = true;
            }

        }
        
        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtName.Text.Trim().Length == 0)
            {
                strErr += "姓名不能为空！\\n";
            }
            if (txtIdCard.Text.Trim().Length == 0)
            {
                strErr += "身份证不能为空！\\n";
            }
            if (txtTel.Text.Trim().Length == 0)
            {
                strErr += "手机号码不能为空！\\n";
            }
            if (int.Parse(CollegeList.SelectedValue) == 0)
            {
                strErr += "学院不能为空！\\n";
            }
            if (int.Parse(MajorList.SelectedValue) == 0)
            {
                strErr += "专业不能为空！\\n";
            }
            if (int.Parse(ClassList.SelectedValue) == 0)
            {
                strErr += "班级不能为空！\\n";
            }
            if (txtSex.Text.Trim().Length == 0)
            {
                strErr += "性别不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }

            string name = txtName.Text;
            string idCard = txtIdCard.Text;
            string tel = txtTel.Text;
            int college = int.Parse(CollegeList.SelectedValue);
            int major = int.Parse(MajorList.SelectedValue);
            int classes = int.Parse(ClassList.SelectedValue);
            string sex = txtSex.Text;

            Eva.Model.WebUser model = Session["user"] as Eva.Model.WebUser;


            model.Name = name;
            model.IdCard = idCard;
            model.Phone = tel;
            model.CollegeId = college;
            model.MajorId = major;
            model.ClassId = classes;
            model.Sex = sex;
            if (bllUser.Update(model))
            {
                Maticsoft.Common.MessageBox.Show(this, "保存成功！");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "保存失败！");
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtOldPassWord.Text.Trim().Length == 0)
            {
                strErr += "原密码不能为空！";
            }
            if (txtPassWord.Text.Trim().Length == 0)
            {
                strErr += "新密码不能为空！";
            }
            if (txtPassWordC.Text.Trim().Length == 0)
            {
                strErr += "重复密码不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }

            string oldpaw = txtOldPassWord.Text;
            string paw = txtPassWord.Text;
            string pawc = txtPassWordC.Text;

            Eva.Model.WebUser model = Session["user"] as Eva.Model.WebUser;

            if (oldpaw != model.PassWord)
            {
                strErr += "原密码不一致！";
            }
            else if (paw != pawc)
            {
                strErr += "两次密码不一致！";
            }
            else
            {
                model.PassWord = paw;
                bllUser.Update(model);
                Maticsoft.Common.MessageBox.Show(this, "修改密码成功！");
            }          

        }

        protected void CollegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMajorList(int.Parse(CollegeList.SelectedItem.Value));
        }

        protected void MajorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClass(int.Parse(MajorList.SelectedItem.Value));
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
        private void LoadClass(int majorId)
        {
            var set = bllCollege.GetList(" MajorId = " + majorId);
            ClassList.Items.Clear();

            ClassList.DataSource = set.Tables["ds"].DefaultView;

            ClassList.DataTextField = "Name";
            ClassList.DataValueField = "Id";
            ClassList.DataBind();
            ClassList.Items.Insert(0, new ListItem("请选择", "0"));

        }
    }
}