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
namespace Eva.Web.ItemList
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
		Eva.BLL.ItemList bll=new Eva.BLL.ItemList();
		Eva.Model.ItemList model=bll.GetModel(Id);
		this.lblId.Text=model.Id.ToString();
		this.lblEvaluationId.Text=model.EvaluationId.ToString();
		this.lblItemId.Text=model.ItemId.ToString();
		this.lblEvaluation.Text=model.Evaluation;
		this.lblscore.Text=model.score.ToString();

	}


    }
}
