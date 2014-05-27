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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtName.Text.Trim().Length==0)
			{
				strErr+="Name不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCredit.Text))
			{
				strErr+="Credit格式错误！\\n";	
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
			string Name=this.txtName.Text;
			int Credit=int.Parse(this.txtCredit.Text);
			string Introdution=this.txtIntrodution.Text;

			Eva.Model.Course model=new Eva.Model.Course();
			model.Name=Name;
			model.Credit=Credit;
			model.Introdution=Introdution;

			Eva.BLL.Course bll=new Eva.BLL.Course();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
