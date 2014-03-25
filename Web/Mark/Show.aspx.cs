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
namespace Eva.Web.Mark
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					int Id=(Convert.ToInt32(strid));
					ShowInfo(Id);
				}
			}
		}
		
	private void ShowInfo(int Id)
	{
		Eva.BLL.Mark bll=new Eva.BLL.Mark();
		Eva.Model.Mark model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblCourseId.Text=model.CourseId.ToString();
		this.lblStudentId.Text=model.StudentId.ToString();
		this.lblEvalutionId.Text=model.EvalutionId.ToString();
		this.lblScore.Text=model.Score.ToString();
		this.lblBonusPoint.Text=model.BonusPoint.ToString();
		this.lblAcademicYear.Text=model.AcademicYear.ToString();
		this.lblSchoolTerm.Text=model.SchoolTerm.ToString();
		this.lblCheckStep.Text=model.CheckStep.ToString();

	}


    }
}
