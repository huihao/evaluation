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
namespace Eva.Web.Mark
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtCourseId.Text))
			{
				strErr+="CourseId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtStudentId.Text))
			{
				strErr+="StudentId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtEvalutionId.Text))
			{
				strErr+="EvalutionId格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtScore.Text))
			{
				strErr+="Score格式错误！\\n";	
			}
			if(!PageValidate.IsDecimal(txtBonusPoint.Text))
			{
				strErr+="BonusPoint格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAcademicYear.Text))
			{
				strErr+="AcademicYear格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSchoolTerm.Text))
			{
				strErr+="SchoolTerm格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCheckStep.Text))
			{
				strErr+="CheckStep格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CourseId=int.Parse(this.txtCourseId.Text);
			int StudentId=int.Parse(this.txtStudentId.Text);
			int EvalutionId=int.Parse(this.txtEvalutionId.Text);
			decimal Score=decimal.Parse(this.txtScore.Text);
			decimal BonusPoint=decimal.Parse(this.txtBonusPoint.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);
			int CheckStep=int.Parse(this.txtCheckStep.Text);

			Eva.Model.Mark model=new Eva.Model.Mark();
			model.CourseId=CourseId;
			model.StudentId=StudentId;
			model.EvalutionId=EvalutionId;
			model.Score=Score;
			model.BonusPoint=BonusPoint;
			model.AcademicYear=AcademicYear;
			model.SchoolTerm=SchoolTerm;
			model.CheckStep=CheckStep;

			Eva.BLL.Mark bll=new Eva.BLL.Mark();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
