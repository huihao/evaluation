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
namespace Eva.Web.Awards
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
		Eva.BLL.Awards bll=new Eva.BLL.Awards();
		Eva.Model.Awards model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblName.Text=model.Name;
		this.lblGrade.Text=model.Grade;
		this.lblScore.Text=model.Score;
		this.lblStudentId.Text=model.StudentId.ToString();
		this.lblAcademicYear.Text=model.AcademicYear.ToString();
		this.lblSchoolTerm.Text=model.SchoolTerm.ToString();
		this.lblIsCheck.Text=model.IsCheck;
		this.lblTotal.Text=model.Total.ToString();

	}


    }
}
