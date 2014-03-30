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
namespace Eva.Web.Teach
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
		Eva.BLL.Teach bll=new Eva.BLL.Teach();
		Eva.Model.Teach model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblCourseId.Text=model.CourseId.ToString();
		this.lblTeacherId.Text=model.TeacherId.ToString();
		this.lblAcademicYear.Text=model.AcademicYear.ToString();
		this.lblSchoolTerm.Text=model.SchoolTerm.ToString();

	}


    }
}
