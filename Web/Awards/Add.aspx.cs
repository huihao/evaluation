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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			string Grade=this.txtGrade.Text;
			string Score=this.txtScore.Text;
			int StudentId=int.Parse(this.txtStudentId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);

			Eva.Model.Awards model=new Eva.Model.Awards();
			model.Name=Name;
			model.Grade=Grade;
			model.Score=Score;
			model.StudentId=StudentId;
			model.AcademicYear=AcademicYear;
			model.SchoolTerm=SchoolTerm;

			Eva.BLL.Awards bll=new Eva.BLL.Awards();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
