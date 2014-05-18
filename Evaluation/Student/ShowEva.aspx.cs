using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Student
{
    public partial class ShowEva : System.Web.UI.Page
    {
        Model.WebUser user = new Model.WebUser();
        Model.Evaluation eva = new Model.Evaluation();
        BLL.Evaluation bllEva = new BLL.Evaluation();
        BLL.ItemList bllItemList = new BLL.ItemList();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetDate();
                EvaBing();
            }

        }
        private void SetDate()
        {
            YearList.Items.Add(new ListItem("", ""));
            for (int i = DateTime.Now.Year-8; i < DateTime.Now.Year; i++)
            {
                YearList.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            Termlist.Items.Add(new ListItem("", ""));
            for (int i = 1; i < 3; i++)
            {
                Termlist.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
        }
        private void EvaBing()
        {
            user = Session["user"] as Model.WebUser;
            int EvaId = bllEva.GetModel(Convert.ToInt16(user.StudentId)).Id;
            var set = bllItemList.GetListByEvaId(EvaId);
            EvaRepeater.DataSource = set;
            EvaRepeater.DataBind();
        }


        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Termlist_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void EvaRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}