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
namespace Eva.Web.ItemList
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
		Eva.BLL.ItemList bll=new Eva.BLL.ItemList();
		Eva.Model.ItemList model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.txtEvaluationId.Text=model.EvaluationId.ToString();
		this.txtItemId.Text=model.ItemId.ToString();
		this.txtEvaluation.Text=model.Evaluation;
		this.txtscore.Text=model.score.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtEvaluationId.Text))
			{
				strErr+="EvaluationId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtItemId.Text))
			{
				strErr+="ItemId格式错误！\\n";	
			}
			if(this.txtEvaluation.Text.Trim().Length==0)
			{
				strErr+="Evaluation不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtscore.Text))
			{
				strErr+="score格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Id=int.Parse(this.lblId.Text);
			int EvaluationId=int.Parse(this.txtEvaluationId.Text);
			int ItemId=int.Parse(this.txtItemId.Text);
			string Evaluation=this.txtEvaluation.Text;
			int score=int.Parse(this.txtscore.Text);


			Eva.Model.ItemList model=new Eva.Model.ItemList();
			model.Id=Id;
			model.EvaluationId=EvaluationId;
			model.ItemId=ItemId;
			model.Evaluation=Evaluation;
			model.score=score;

			Eva.BLL.ItemList bll=new Eva.BLL.ItemList();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
