using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Admin
{
    public partial class AddUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";
         
            if (this.txtPassWord.Text.Trim().Length == 0)
            {
                strErr += "PassWord不能为空！\\n";
            }
      
            if (this.txtName.Text.Trim().Length == 0)
            {
                strErr += "Name不能为空！\\n";
            }
         
            if (this.txtIdCard.Text.Trim().Length == 0)
            {
                strErr += "IdCard不能为空！\\n";
            }
            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
                return;
            }
          
            string PassWord = this.txtPassWord.Text;
            string Name = this.txtName.Text;
            string IdCard = this.txtIdCard.Text;
            Eva.Model.WebUser model = new Eva.Model.WebUser();
            model.PassWord = PassWord;
            model.Name = Name;
            model.IdCard = IdCard;


            Eva.BLL.WebUser bll = new Eva.BLL.WebUser();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "UserList.aspx");
        }
    }
}