using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Eva.Evaluation.Student
{
    public partial class StuInfo : System.Web.UI.Page
    {
        Eva.BLL.College bllCollege = new BLL.College();
        Eva.BLL.WebUser bllUser = new BLL.WebUser();
        Eva.BLL.Major bllMajor = new BLL.Major();
        Eva.BLL.Class bllClass = new BLL.Class();
        Eva.Model.WebUser stu = new Model.WebUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                stu = Session["user"] as Model.WebUser;
                txtName.Text = stu.Name;
                txtIdCard.Text = stu.IdCard;
                txtSex.Text = stu.Sex;
                txtTel.Text = stu.Phone;

                DataSet collegeDS = bllCollege.GetAllList();
                CollegeList.DataSource = collegeDS.Tables["ds"].DefaultView;
                CollegeList.DataTextField = "Name";
                CollegeList.DataValueField = "Id";
                CollegeList.DataBind();
                CollegeList.Items.FindByValue(stu.CollegeId.ToString()).Selected = true;

                LoadMajor(Convert.ToInt32(stu.CollegeId));
                MajorList.Items.FindByValue(stu.MajorId.ToString()).Selected = true;

                LoadClass(Convert.ToInt32(stu.MajorId));
                ClassList.Items.FindByValue(stu.ClassId.ToString()).Selected = true;



            }

        }
        private void LoadMajor(int collegeId)
        {
            MajorList.Items.Clear();
            DataSet MajorDs = bllMajor.GetList(" CollegeId=" + collegeId);
            MajorList.DataSource = MajorDs.Tables["ds"].DefaultView;
            MajorList.DataTextField = "Name";
            MajorList.DataValueField = "Id";
            MajorList.DataBind();
            MajorList.Items.Insert(0,new ListItem("请选择", "0"));


        }
        private void LoadClass(int MajorId)
        {
            ClassList.Items.Clear();
            DataSet ClassDs = bllClass.GetList(" MajorId=" + MajorId);
            ClassList.DataSource = ClassDs.Tables["ds"].DefaultView;
            ClassList.DataTextField = "Name";
            ClassList.DataValueField = "Id";
            ClassList.DataBind();
            ClassList.Items.Insert(0,new ListItem("请选择", "0"));
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

            if (txtSex.Text.Trim().Length == 0)
            {
                strErr += "性别不能为空！\\n";
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
            LoadMajor(int.Parse(CollegeList.SelectedItem.Value));
            LoadClass(int.Parse(MajorList.SelectedItem.Value));
        }

        protected void MajorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClass(int.Parse(MajorList.SelectedItem.Value));
        }


    }
}