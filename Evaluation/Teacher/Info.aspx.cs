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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                DataSet ds = bllCollege.GetAllList();
                ddCollege.Items.Clear();
                ddCollege.DataSource = ds.Tables["ds"].DefaultView;

                ddCollege.DataTextField = "Name";
                ddCollege.DataValueField = "Id";
                ddCollege.DataBind();
                ddCollege.Items.Insert(0, new ListItem("请选择", "0"));
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
            if (ddCollege.SelectedIndex == 0)
            {
                strErr += "学院不能为空！\\n";
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
            int college = int.Parse(ddCollege.SelectedValue);
            string sex = txtSex.Text;

            Eva.Model.WebUser model = Session["user"] as Eva.Model.WebUser;


            model.Name = name;
            model.IdCard = idCard;
            model.Phone = tel;
            model.CollegeId = college;
            model.Sex = sex;

            bllUser.Update(model);
            Maticsoft.Common.MessageBox.Show(this, "保存成功！");
            

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
    }
}