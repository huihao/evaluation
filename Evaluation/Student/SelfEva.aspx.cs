using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class SelfEva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

       

      

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
            if (txtSelf.Text.Trim().Length == 0)
            {
                strErr += "自评不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
            Eva.BLL.Evaluation bllEva = Eva.BLL.BLLFactory.GetEvaluationBLLInstance();
            Eva.Model.Evaluation eva = new Model.Evaluation();
            int id = int.Parse(Request["id"]);
            eva = bllEva.GetModel(id);
            eva.SelfEvaluation = txtSelf.Text;
            if (bllEva.Update(eva))
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "自评成功！", "ShowEva.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "自评失败！");
            }
        }
    }
}