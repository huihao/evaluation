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
		Eva.BLL.Evaluation bll=new Eva.BLL.Evaluation();
		Eva.Model.Evaluation model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtStudentId.Text=model.StudentId.ToString();
		this.txtAcademicYear.Text=model.AcademicYear.ToString();
		this.txtGpa.Text=model.Gpa.ToString();
		this.txtAve.Text=model.Ave.ToString();
		this.txtTeacherEvaluation.Text=model.TeacherEvaluation;
		this.txtSelfEvaluation.Text=model.SelfEvaluation;
		this.txtTeacherId.Text=model.TeacherId.ToString();
		this.txtSchoolTerm.Text=model.SchoolTerm.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int Id=int.Parse(this.lblId.Text);
			int StudentId=int.Parse(this.txtStudentId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			decimal Gpa=decimal.Parse(this.txtGpa.Text);
			decimal Ave=decimal.Parse(this.txtAve.Text);
			string TeacherEvaluation=this.txtTeacherEvaluation.Text;
			string SelfEvaluation=this.txtSelfEvaluation.Text;
			int TeacherId=int.Parse(this.txtTeacherId.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);


			Eva.Model.Evaluation model=new Eva.Model.Evaluation();
			model.Id=Id;
			model.StudentId=StudentId;
			model.AcademicYear=AcademicYear;
			model.Gpa=Gpa;
			model.Ave=Ave;
			model.TeacherEvaluation=TeacherEvaluation;
			model.SelfEvaluation=SelfEvaluation;
			model.TeacherId=TeacherId;
			model.SchoolTerm=SchoolTerm;

			Eva.BLL.Evaluation bll=new Eva.BLL.Evaluation();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
