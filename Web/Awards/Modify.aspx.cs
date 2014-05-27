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
namespace Eva.Web.Awards
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
		Eva.BLL.Awards bll=new Eva.BLL.Awards();
		Eva.Model.Awards model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtName.Text=model.Name;
		this.txtGrade.Text=model.Grade;
		this.txtScore.Text=model.Score;
		this.txtStudentId.Text=model.StudentId.ToString();
		this.txtAcademicYear.Text=model.AcademicYear.ToString();
		this.txtSchoolTerm.Text=model.SchoolTerm.ToString();
		this.txtIsCheck.Text=model.IsCheck;
		this.txtTotal.Text=model.Total.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(this.txtGrade.Text.Trim().Length==0)
			{
				strErr+="Grade不能为空！\\n";	
			}
			if(this.txtScore.Text.Trim().Length==0)
			{
				strErr+="Score不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtStudentId.Text))
			{
				strErr+="StudentId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAcademicYear.Text))
			{
				strErr+="AcademicYear格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSchoolTerm.Text))
			{
				strErr+="SchoolTerm格式错误！\\n";	
			}
			if(this.txtIsCheck.Text.Trim().Length==0)
			{
				strErr+="IsCheck不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtTotal.Text))
			{
				strErr+="Total格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string Name=this.txtName.Text;
			string Grade=this.txtGrade.Text;
			string Score=this.txtScore.Text;
			int StudentId=int.Parse(this.txtStudentId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);
			string IsCheck=this.txtIsCheck.Text;
			int Total=int.Parse(this.txtTotal.Text);


			Eva.Model.Awards model=new Eva.Model.Awards();
			model.Id=Id;
			model.Name=Name;
			model.Grade=Grade;
			model.Score=Score;
			model.StudentId=StudentId;
			model.AcademicYear=AcademicYear;
			model.SchoolTerm=SchoolTerm;
			model.IsCheck=IsCheck;
			model.Total=Total;

			Eva.BLL.Awards bll=new Eva.BLL.Awards();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
