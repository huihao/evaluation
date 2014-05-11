using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtUserName.Text.Trim().Length==0)
            {
                strErr += "用户名不能为空！";
            }
            if (txtPaw.Text.Trim().Length==0)
            {
                strErr += "密码不能为空！";
            }
            if (strErr!="")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            Eva.BLL.WebUser bllUser = new BLL.WebUser();
            Eva.Model.WebUser user = new Model.WebUser();
            string loginId = txtUserName.Text;
            string passWord = txtPaw.Text;
            user = bllUser.Login(loginId, passWord);
            if (user != null)
            {
                Session["user"] = user;
                if (user.AuthorityId == 1)
                {
                    Response.Redirect("Student/ShowMark.aspx");
                }
                if (user.AuthorityId == 2)
                {
                    Response.Redirect("Teacher/StudentList.aspx");
                }
                if (user.AuthorityId == 3)
                {
                    Response.Redirect("Admin/ListUser.aspx");
                }
            }
            else {
                Maticsoft.Common.MessageBox.Show(this, "密码或用户名错误！");
            }
        }
    }
}