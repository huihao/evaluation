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
namespace Eva.Web.Course
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
		Eva.BLL.Course bll=new Eva.BLL.Course();
		Eva.Model.Course model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtName.Text=model.Name;
		this.txtGpa.Text=model.Gpa.ToString();
		this.txtIntrodution.Text=model.Introdution;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGpa.Text))
			{
				strErr+="Gpa格式错误！\\n";	
			}
			if(this.txtIntrodution.Text.Trim().Length==0)
			{
				strErr+="Introdution不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			string Name=this.txtName.Text;
			decimal Gpa=decimal.Parse(this.txtGpa.Text);
			string Introdution=this.txtIntrodution.Text;


			Eva.Model.Course model=new Eva.Model.Course();
			model.Id=Id;
			model.Name=Name;
			model.Gpa=Gpa;
			model.Introdution=Introdution;

			Eva.BLL.Course bll=new Eva.BLL.Course();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
