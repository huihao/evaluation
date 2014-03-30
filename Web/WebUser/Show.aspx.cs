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
namespace Eva.Web.WebUser
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
		Eva.BLL.WebUser bll=new Eva.BLL.WebUser();
		Eva.Model.WebUser model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblLoginId.Text=model.LoginId;
		this.lblPassWord.Text=model.PassWord;
		this.lblAuthorityId.Text=model.AuthorityId.ToString();
		this.lblName.Text=model.Name;
		this.lblStudentId.Text=model.StudentId.ToString();
		this.lblSex.Text=model.Sex;
		this.lblCollegeId.Text=model.CollegeId.ToString();
		this.lblClassId.Text=model.ClassId.ToString();
		this.lblMajorId.Text=model.MajorId.ToString();
		this.lblIdCard.Text=model.IdCard;
		this.lblAddress.Text=model.Address;
		this.lblPhone.Text=model.Phone;

	}


    }
}
