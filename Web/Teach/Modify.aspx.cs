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
namespace Eva.Web.Teach
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
		Eva.BLL.Teach bll=new Eva.BLL.Teach();
		Eva.Model.Teach model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtCourseId.Text=model.CourseId.ToString();
		this.txtTeacherId.Text=model.TeacherId.ToString();
		this.txtAcademicYear.Text=model.AcademicYear.ToString();
		this.txtSchoolTerm.Text=model.SchoolTerm.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtCourseId.Text))
			{
				strErr+="CourseId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTeacherId.Text))
			{
				strErr+="TeacherId格式错误！\\n";	
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
			int Id=int.Parse(this.lblId.Text);
			int CourseId=int.Parse(this.txtCourseId.Text);
			int TeacherId=int.Parse(this.txtTeacherId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);


			Eva.Model.Teach model=new Eva.Model.Teach();
			model.Id=Id;
			model.CourseId=CourseId;
			model.TeacherId=TeacherId;
			model.AcademicYear=AcademicYear;
			model.SchoolTerm=SchoolTerm;

			Eva.BLL.Teach bll=new Eva.BLL.Teach();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
