﻿using System;
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
				strErr+="课程名称不能为空！\\n";	
			}
			if(!PageValidate.IsDecimal(txtGpa.Text))
			{
				strErr+="绩点格式错误！\\n";	
			}
			if(this.txtIntrodution.Text.Trim().Length==0)
			{
				strErr+="课程介绍不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string Name=this.txtName.Text;
			decimal Gpa=decimal.Parse(this.txtGpa.Text);
			string Introdution=this.txtIntrodution.Text;

			Eva.Model.Course model=new Eva.Model.Course();
			model.Name=Name;
			model.Gpa=Gpa;
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
