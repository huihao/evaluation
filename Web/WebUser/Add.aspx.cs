using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace Eva.Web.WebUser
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtLoginId.Text.Trim().Length==0)
			{
				strErr+="登录名不能为空！\\n";	
			}
			if(this.txtPassWord.Text.Trim().Length==0)
			{
				strErr+="密码不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAuthorityId.Text))
			{
				strErr+="权限格式错误！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="真实姓名不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtStudentId.Text))
			{
				strErr+="学号格式错误！\\n";	
			}
			if(this.txtSex.Text.Trim().Length==0)
			{
				strErr+="性别不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCollegeId.Text))
			{
				strErr+="学院ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtClassId.Text))
			{
				strErr+="班级ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMajorId.Text))
			{
				strErr+="专业ID格式错误！\\n";	
			}
			if(this.txtIdCard.Text.Trim().Length==0)
			{
				strErr+="身份证号码不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="联系地址不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="电话号码不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string LoginId=this.txtLoginId.Text;
			string PassWord=this.txtPassWord.Text;
			int AuthorityId=int.Parse(this.txtAuthorityId.Text);
			string Name=this.txtName.Text;
			int StudentId=int.Parse(this.txtStudentId.Text);
			string Sex=this.txtSex.Text;
			int CollegeId=int.Parse(this.txtCollegeId.Text);
			int ClassId=int.Parse(this.txtClassId.Text);
			int MajorId=int.Parse(this.txtMajorId.Text);
			string IdCard=this.txtIdCard.Text;
			string Address=this.txtAddress.Text;
			string Phone=this.txtPhone.Text;

			Eva.Model.WebUser model=new Eva.Model.WebUser();
			model.LoginId=LoginId;
			model.PassWord=PassWord;
			model.AuthorityId=AuthorityId;
			model.Name=Name;
			model.StudentId=StudentId;
			model.Sex=Sex;
			model.CollegeId=CollegeId;
			model.ClassId=ClassId;
			model.MajorId=MajorId;
			model.IdCard=IdCard;
			model.Address=Address;
			model.Phone=Phone;

			Eva.BLL.WebUser bll=new Eva.BLL.WebUser();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
