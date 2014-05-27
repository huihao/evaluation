using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Eva.Evaluation.Teacher
{
    /// <summary>
    /// EvaluationHandler 的摘要说明
    /// </summary>
    public class EvaluationHandler : IHttpHandler, IRequiresSessionState
    {
        BLL.Item itemBll = BLL.BLLFactory.GetItemBLLInstance();
        BLL.ItemList itemListBll = BLL.BLLFactory.GetItemListBLLInstance();
        BLL.Evaluation evaBll = BLL.BLLFactory.GetEvaluationBLLInstance();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            var items = itemBll.GetModelList("");

            if (context.Request["ctl00$ContentPlaceHolder1$studentId"] != null)
            {
                int id = int.Parse(context.Request["ctl00$ContentPlaceHolder1$studentId"]);
                //int teacherId = Convert.ToInt32((context.Session["user"] as Model.WebUser).Id);
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
                eva.StudentId = id;
                //todo
                eva.TeacherId = 1;
                int evaID = evaBll.Add(eva);
                if (evaID > 0)
                {
                    foreach (var item in items)
                    {
                        if (context.Request["score" + item.Id] != null && context.Request["word" + item.Id] != null)
                        {
                            int score = int.Parse(context.Request["score" + item.Id].ToString());
                            string word = context.Request["word" + item.Id].ToString();

                            var itemList = new Model.ItemList();
                            itemList.EvaluationId = evaID;
                            itemList.ItemId = item.Id;
                            itemList.score = score;
                            itemList.Evaluation = word;

                            itemListBll.Add(itemList);
                        }
                    }
                    context.Response.Redirect("StudentList.aspx");
                }
            }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}