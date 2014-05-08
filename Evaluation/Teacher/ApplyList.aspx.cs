using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Teacher
{
    public partial class ApplyList : System.Web.UI.Page
    {
        Eva.BLL.Mark bll = new BLL.Mark();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                markBing();
            }

        }
        private void markBing()
        {
            Eva.Model.WebUser teacher = Session["user"] as Eva.Model.WebUser;
            var set = bll.getListByCheckStep(teacher.Id);
            MarkRepeater.DataSource = set;
            MarkRepeater.DataBind();
        }

        protected void MarkRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt16(e.CommandArgument);
            Eva.Model.Mark mark = new Model.Mark();
            mark = bll.GetModel(id);
            if (e.CommandName == "yes")
            {
                
                mark.Score = mark.Score + mark.BonusPoint;
                mark.CheckStep = 2;
                bll.Update(mark);
                markBing();
            }
            if (e.CommandName == "no")
            {
                mark.CheckStep = 3;
                bll.Update(mark);
                markBing();
               
            }
        }

    }
}