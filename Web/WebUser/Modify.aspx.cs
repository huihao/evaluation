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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int Id=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(Id);
				}
			}
		}
			
	private void ShowInfo(int Id)
	{
		Eva.BLL.WebUser bll=new Eva.BLL.WebUser();
		Eva.Model.WebUser model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtLoginId.Text=model.LoginId;
		this.txtPassWord.Text=model.PassWord;
		this.txtAuthorityId.Text=model.AuthorityId.ToString();
		this.txtName.Text=model.Name;
		this.txtStudentId.Text=model.StudentId.ToString();
		this.txtSex.Text=model.Sex;
		this.txtCollegeId.Text=model.CollegeId.ToString();
		this.txtClassId.Text=model.ClassId.ToString();
		this.txtMajorId.Text=model.MajorId.ToString();
		this.txtIdCard.Text=model.IdCard;
		this.txtAddress.Text=model.Address;
		this.txtPhone.Text=model.Phone;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtLoginId.Text.Trim().Length==0)
			{
				strErr+="LoginId不能为空！\\n";	
			}
			if(this.txtPassWord.Text.Trim().Length==0)
			{
				strErr+="PassWord不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtAuthorityId.Text))
			{
				strErr+="AuthorityId格式错误！\\n";	
			}
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtStudentId.Text))
			{
				strErr+="StudentId格式错误！\\n";	
			}
			if(this.txtSex.Text.Trim().Length==0)
			{
				strErr+="Sex不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCollegeId.Text))
			{
				strErr+="CollegeId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtClassId.Text))
			{
				strErr+="ClassId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtMajorId.Text))
			{
				strErr+="MajorId格式错误！\\n";	
			}
			if(this.txtIdCard.Text.Trim().Length==0)
			{
				strErr+="IdCard不能为空！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtPhone.Text.Trim().Length==0)
			{
				strErr+="Phone不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
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
			model.Id=Id;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
