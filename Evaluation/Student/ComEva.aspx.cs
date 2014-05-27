using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class ComEva : System.Web.UI.Page
    {
        Model.WebUser user = new Model.WebUser();
        Model.Evaluation eva = new Model.Evaluation();
        BLL.Evaluation bllEva = new BLL.Evaluation();
        BLL.ItemList bllItemList = new BLL.ItemList();

        Eva.BLL.Mark bllMark = new BLL.Mark();
        Eva.BLL.Item bllItem = new BLL.Item();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDate();
                Bing();
                MarkBing();
            }

        }
        private void MarkBing()
        {
            MarkRepeater.DataSource = bllMark.GetListByStudentId(Convert.ToInt32(user.StudentId), YearList.SelectedValue, Termlist.SelectedValue);
            MarkRepeater.DataBind();
        }

        private void EvaBing()
        {
 
        }

        private void Bing()
        {
            user = Session["user"] as Model.WebUser;
            Name.Text = user.Name;

            decimal ave = Ave(Convert.ToInt32(user.StudentId));

            List<Eva.Model.Evaluation> list = bllEva.GetModelList(string.Format("StudentId={0} and AcademicYear={1} and SchoolTerm={2}", user.Id, YearList.SelectedValue, Termlist.SelectedValue));

            if (list.Count > 0)
            {
                eva = list[0] as Model.Evaluation;
                eva.Ave = Convert.ToDecimal(ave);
                bllEva.Update(eva);
            }

            List<Eva.Model.ItemList> ItemList = bllItemList.GetModelList(" EvaluationId=" + eva.Id);

            decimal sum = 0;
            decimal sumValue = 0;
            if (ItemList.Count > 0)
            {
                for (int i = 0; i < ItemList.Count; i++)
                {
                    sum += Convert.ToInt32(ItemList[i].Evaluation) * Convert.ToInt32(bllItem.GetModel(Convert.ToInt32(ItemList[i].ItemId)).Value) / 100;

                }

            }
            List<Eva.Model.Item> list1 = bllItem.GetModelAllList();
            for (int i = 0; i < list1.Count; i++)
            {
                sumValue += Convert.ToInt32(list1[i].Value);
            }
            sum = sum + ave * (100 - sumValue) / 100;
            eva.Total = sum;

            bllEva.Update(eva);

            txtSelf.Text = eva.SelfEvaluation;
            txtTeacherEva.Text = eva.TeacherEvaluation;
            txtAve.Text = ave.ToString();
            txtComEva.Text = sum.ToString();

        }
        private void SetDate()
        {
            for (int i = DateTime.Now.Year - 8; i <= DateTime.Now.Year; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }



        private decimal Ave(int stuId)
        {
            string sql = " StudentId=" + stuId + " and AcademicYear=" + int.Parse(YearList.SelectedValue) + " and SchoolTerm=" + int.Parse(Termlist.SelectedValue);
            List<Eva.Model.Mark> list = bllMark.GetModelList(sql);
            int sum = 0;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    sum += Convert.ToInt32(list[i].Score);
                }
                return sum / list.Count;
            }
            else
            {
                return 0;
            }


        }


        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bing();
            MarkBing();
        }

        protected void Termlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bing();
            MarkBing();
        }

    }
}