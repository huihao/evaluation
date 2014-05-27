using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eva.Evaluation.Teacher
{
    public partial class Evaluation : System.Web.UI.Page
    {
        BLL.Item itemBll = BLL.BLLFactory.GetItemBLLInstance();
        BLL.Awards award = BLL.BLLFactory.GetAwardsBLLInstance();
        BLL.ItemList itemListBll = BLL.BLLFactory.GetItemListBLLInstance();
        BLL.Evaluation evaBll = BLL.BLLFactory.GetEvaluationBLLInstance();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = Convert.ToInt32(Request["id"]);
                studentId.Value = id.ToString();
                ItemRepeater.DataSource = itemBll.GetAllList();
                ItemRepeater.DataBind();
            }
        }

        protected void ItemRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            HiddenField hf = (HiddenField)e.Item.FindControl("ItemId");
            if (hf.Value == "2")
            {
                Repeater ExplainRepeater = (Repeater)e.Item.FindControl("ExplainRepeater");
                int SchoolTerm;
                if (DateTime.Now.Month > 8 || DateTime.Now.Month < 2)
                {
                    SchoolTerm = 1;
                }
                else
                {
                    SchoolTerm = 2;
                }

                ExplainRepeater.DataSource = award.GetList(" StudentId=" + studentId.Value + " And SchoolTerm = " + SchoolTerm + " and AcademicYear = " + DateTime.Now.Year);
                ExplainRepeater.DataBind();
                TextBox score = (TextBox)e.Item.FindControl("score");
                score.Text = "80";
                score.Enabled = false;
            }
        }

        protected void ExplainRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "yes")
            {
                var a = award.GetModel(Convert.ToInt32(e.CommandArgument));
                Button bt = (Button)e.Item.FindControl("btnOK");
                if (bt.Text == "同意")
                {
                    a.IsCheck = "同意";
                    award.Update(a);    
                    ItemRepeater.DataSource = itemBll.GetAllList();
                    ItemRepeater.DataBind();
               
                    Maticsoft.Common.MessageBox.Show(this, "已同意");
                }
                else
                {
                    a.IsCheck = "不同意";
                    award.Update(a);   
                    ItemRepeater.DataSource = itemBll.GetAllList();
                    ItemRepeater.DataBind();
                 
                    Maticsoft.Common.MessageBox.Show(this, "已否决");
                }

            }


        }

        protected void ItemRepeater_ItemCreated(object sender, RepeaterItemEventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                var user = Session["user"] as Model.WebUser;
                if (user.AuthorityId == 2)
                {
                    var items = itemBll.GetModelList("");
                    var eva = new Model.Evaluation();
                    if (DateTime.Now.Month > 8 || DateTime.Now.Month < 2)
                    {
                        eva.SchoolTerm = 1;
                    }
                    else
                    {
                        eva.SchoolTerm = 2;
                    }

                    eva.AcademicYear = DateTime.Now.Year;
                    eva.StudentId = int.Parse(studentId.Value);
                    //todo
                    eva.TeacherId = 1;
                    int evaID = evaBll.Add(eva);
                    if (evaID > 0)
                    {
                        for (int i = 0; i < ItemRepeater.Controls.Count; i++)
                        {
                            HiddenField ItemId = (HiddenField)ItemRepeater.Items[i].FindControl("ItemId");
                            TextBox score = (TextBox)ItemRepeater.Items[i].FindControl("score");
                            TextBox word = (TextBox)ItemRepeater.Items[i].FindControl("word");

                            var itemList = new Model.ItemList();
                            itemList.EvaluationId = evaID;
                            itemList.ItemId = int.Parse(ItemId.Value);

                            itemList.Evaluation = word.Text;
                            if (ItemId.Value == "2")
                            {
                                itemList.score = 80;
                                var list = award.GetModelList("StudentId=" + studentId.Value + " And SchoolTerm = " + eva.SchoolTerm + " and AcademicYear = " + DateTime.Now.Year);
                                foreach (var item in list)
                                {
                                    if (item.IsCheck == "同意")
                                    {
                                        itemList.score += item.Total;
                                    }
                                }
                            }
                            else
                            {
                                itemList.score = int.Parse(score.Text);
                            }
                            itemListBll.Add(itemList);
                        }
                    }
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "评价成功！", "StudentList.aspx");
                }
                else
                {
                    Maticsoft.Common.MessageBox.ShowAndRedirect(this, "权限限制，请重新登录", "../login.aspx");
                }
            }
            else
            {
                Maticsoft.Common.MessageBox.ShowAndRedirect(this, "权限限制，请重新登录", "../login.aspx");
            }
        }
    }
}