using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class AddAward : System.Web.UI.Page
    {
        Model.Awards award = new Model.Awards();
        BLL.Awards bll = new BLL.Awards();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDate();
            }
        }



        protected void SetDate()
        {
            YearList.Items.Add(new ListItem("", ""));
            for (int i = 2010; i < 2014; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            Termlist.Items.Add(new ListItem("", ""));
            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            GradeList.Items.Add(new ListItem("", ""));
            GradeList.Items.Add(new ListItem("国级", "3"));
            GradeList.Items.Add(new ListItem("省级", "2"));
            GradeList.Items.Add(new ListItem("市级", "1"));

            ScoreList.Items.Add(new ListItem("", ""));
            ScoreList.Items.Add(new ListItem("一等奖", "3"));
            ScoreList.Items.Add(new ListItem("二等奖", "2"));
            ScoreList.Items.Add(new ListItem("三等奖", "1"));



        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var user = Session["user"] as Model.WebUser;

            string strErr = "";
            if (txtName.Text.Trim().Length == 0)
            {
                strErr += "成果名称不能为空！";
            }

            if (strErr != "")
            {
                Maticsoft.Common.MessageBox.Show(this, strErr);
            }

            award.AcademicYear = int.Parse(YearList.SelectedValue);
            award.SchoolTerm = int.Parse(Termlist.SelectedValue);
            award.Name = txtName.Text;
            award.Grade = GradeList.SelectedItem.Text;
            award.Score = ScoreList.SelectedItem.Text;
            award.Total = int.Parse(GradeList.SelectedItem.Value) * int.Parse(ScoreList.SelectedItem.Value);
            award.IsCheck = "未审核";
            //todo
            award.StudentId = user.Id;

            if (bll.Add(award) != 0)
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "添加成功!", "AwardList.aspx");
            }
            else
            {
                Maticsoft.Common.MessageBox.Show(this, "添加失败!");
            }

        }


    }
}