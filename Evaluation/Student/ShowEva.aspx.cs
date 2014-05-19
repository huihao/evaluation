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
                user = Session["user"] as Model.WebUser;
                Name.Text = user.Name;
                SetDate();
                EvaBing();
            }

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
        private void EvaBing()
        {
            user = Session["user"] as Model.WebUser;
            var eva = bllEva.GetModelList(string.Format("StudentId={0} and AcademicYear={1} and SchoolTerm={2}", user.Id, YearList.SelectedValue, Termlist.SelectedValue));
            if (eva.Count > 0)
            {
                var set = bllItemList.GetListByEvaId(eva[0].Id);
                EvaRepeater.DataSource = set;
                EvaRepeater.DataBind();
            }
            else
            {
                EvaRepeater.DataSource = null;
                DataBind();
            }
        }


        protected void YearList_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaBing();
        }

        protected void Termlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            EvaBing();
        }

        protected void EvaRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }

        protected void btnSelf_Click(object sender, EventArgs e)
        {
            user = Session["user"] as Model.WebUser;
            var eva = bllEva.GetModelList(string.Format("StudentId={0} and AcademicYear={1} and SchoolTerm={2}", user.Id, YearList.SelectedValue, Termlist.SelectedValue));
            int id = eva[0].Id;
            Response.Redirect("SelfEva.aspx?id=" + id);
        }
    }
}