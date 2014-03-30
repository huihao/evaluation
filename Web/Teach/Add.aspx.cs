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
				strErr+="课程ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtTeacherId.Text))
			{
				strErr+="教师ID格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtAcademicYear.Text))
			{
				strErr+="学年格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtSchoolTerm.Text))
			{
				strErr+="学期格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int CourseId=int.Parse(this.txtCourseId.Text);
			int TeacherId=int.Parse(this.txtTeacherId.Text);
			int AcademicYear=int.Parse(this.txtAcademicYear.Text);
			int SchoolTerm=int.Parse(this.txtSchoolTerm.Text);

			Eva.Model.Teach model=new Eva.Model.Teach();
			model.CourseId=CourseId;
			model.TeacherId=TeacherId;
			model.AcademicYear=AcademicYear;
			model.SchoolTerm=SchoolTerm;

			Eva.BLL.Teach bll=new Eva.BLL.Teach();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
