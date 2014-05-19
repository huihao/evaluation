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
namespace Eva.Web.Evaluation
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtStudentId.Text))
			{
				strErr+="StudentId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAcademicYear.Text))
			{
				strErr+="AcademicYear格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGpa.Text))
			{
				strErr+="Gpa格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtAve.Text))
			{
				strErr+="Ave格式错误！\\n";	
			}
			if(this.txtTeacherEvaluation.Text.Trim().Length==0)
			{
				strErr+="TeacherEvaluation不能为空！\\n";	
			}
			if(this.txtSelfEvaluation.Text.Trim().Length==0)
			{
				strErr+="SelfEvaluation不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtTeacherId.Text))
			{
				strErr+="TeacherId格式错误！\\n";	
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
			int StudentId=int.Parse(this.txtStudentId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			decimal Gpa=decimal.Parse(this.txtGpa.Text);
			decimal Ave=decimal.Parse(this.txtAve.Text);
			string TeacherEvaluation=this.txtTeacherEvaluation.Text;
			string SelfEvaluation=this.txtSelfEvaluation.Text;
			int TeacherId=int.Parse(this.txtTeacherId.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);

			Eva.Model.Evaluation model=new Eva.Model.Evaluation();
			model.StudentId=StudentId;
			model.AcademicYear=AcademicYear;
			model.Gpa=Gpa;
			model.Ave=Ave;
			model.TeacherEvaluation=TeacherEvaluation;
			model.SelfEvaluation=SelfEvaluation;
			model.TeacherId=TeacherId;
			model.SchoolTerm=SchoolTerm;

			Eva.BLL.Evaluation bll=new Eva.BLL.Evaluation();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
