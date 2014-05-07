using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class MarkApply : System.Web.UI.Page
    {
        Eva.BLL.Mark bllMark = new BLL.Mark();
        Eva.Model.Mark mark = new Model.Mark();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                int id = int.Parse(Request["id"]);
                mark = bllMark.GetModel(id);
                
                txtCourseName.Text = Eva.BLL.Utils.GetCourseName(Convert.ToInt16(mark.CourseId));
                txtScore.Text = mark.Score.ToString();

            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtBonusPoint.Text.Trim().Length == 0)
            {
                strErr += "加分的分数不能为空！";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show( this,strErr);
                return;
            }
            mark.BonusPoint =  Convert.ToDecimal( txtBonusPoint.Text);
            mark.CheckStep = 1;
            bllMark.Update(mark);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "ShowMark.aspx");
        }
    }
}