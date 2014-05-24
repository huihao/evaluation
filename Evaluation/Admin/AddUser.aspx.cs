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
        BLL.College collegeBll = BLL.BLLFactory.GetCollegeBLLInstance();
        BLL.Major majorBll = BLL.BLLFactory.GetMajorBLLInstance();
        BLL.Class classBll = BLL.BLLFactory.GetClassBLLInstance();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var collegeList = collegeBll.GetModelList("");
                for (int i = 0; i < collegeList.Count; i++)
                {
                    CollegeList.Items.Add(new ListItem(collegeList[i].Name, collegeList[i].Id.ToString()));
                }

                LoadMajorList();
                LoadClassList();
            }
        }

        protected void LoadMajorList()
        {
            MajorList.Items.Clear();
            var majorList = majorBll.GetModelListByCollegeId(CollegeList.SelectedItem.Value);
            for (int i = 0; i < majorList.Count; i++)
            {
                MajorList.Items.Add(new ListItem(majorList[i].Name, majorList[i].Id.ToString()));
            }
        }

        protected void LoadClassList()
        {
            ClassList.Items.Clear();
            var classList = classBll.GetModelListByMajorId(MajorList.SelectedItem.Value);
            for (int i = 0; i < classList.Count; i++)
            {
                ClassList.Items.Add(new ListItem(classList[i].Name, classList[i].Id.ToString()));
            }
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            string strErr = "";



            if (this.txtLogin.Text.Trim().Length==0)
            {
                strErr += "用户名不能为空！\\n";
            }
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
            model.LoginId = txtLogin.Text;
            model.PassWord = PassWord;
            model.Name = Name;
            model.IdCard = IdCard;


            Eva.BLL.WebUser bll = new Eva.BLL.WebUser();
            bll.Add(model);
            Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "UserList.aspx");
        }

        protected void CollegeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMajorList();
            LoadClassList();
        }

        protected void MajorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadClassList();
        }
    }
}