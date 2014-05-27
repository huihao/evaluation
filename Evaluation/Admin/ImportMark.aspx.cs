using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using Eva.BLL;
using Maticsoft.Common;

namespace Eva.Evaluation.Admin
{
    public partial class ImportMark : System.Web.UI.Page
    {

        BLL.WebUser userBll = BLLFactory.GetWebUserBLLInstance();
        BLL.Mark markBll = BLLFactory.GetMarkBLLInstance();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpload_Click1(object sender, EventArgs e)
        {
            try
            {
                if (FileUpload1.PostedFile.FileName == "")
                    this.Upload_info.Text = "请选择上传文件";
                else
                {
                    string filePath = FileUpload1.PostedFile.FileName;
                    if (ISAllowedExtension(filePath) == true)
                    {
                        string filename = "学生数据导入" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls";
                        string serverPath = Server.MapPath("~/FilesUp/") + filename;
                        FileUpload1.PostedFile.SaveAs(serverPath);
                        datalists(Server.MapPath("~/FilesUp/") + filename);
                        this.Upload_info.Text = "上传成功!";
                        btnSubmit.Visible = true;
                        btnSubmit.Enabled = CanSubmit();
                    }
                    else
                        this.Upload_info.Text = "请上传Excel文件！";
                }
            }
            catch (Exception ex)
            {
                this.Upload_info.Text = "上传发生错误！原因是：" + ex.ToString();
            }
        }
        private static bool ISAllowedExtension(string filename)
        {
            string extension = Path.GetExtension(filename);
            return extension.ToLower() == ".xls" ? true : false;
        }
        protected void datalists(string filename)
        {
            DataTable DS = Maticsoft.Common.ExcelHelper.Import(filename);
            ViewState["table"] = DS;
            this.Repeater1.DataSource = DS;
            this.Repeater1.DataBind();
        }
        protected bool CanSubmit()
        {
            DataTable dt = ViewState["table"] as DataTable;

            if (dt.Rows.Count == 0)
            {
                Maticsoft.Common.MessageBox.Show(this, "上传数据不能为空");
                return false;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int stuId = BLL.Utils.GetStuIdByName(dt.Rows[i]["学生姓名"].ToString());
                int corId = BLL.Utils.GetCourseIdByName(dt.Rows[i]["课程"].ToString());
               
                if (stuId == -1)
                {
                    this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,不存在‘{1}’这个学生。<span>",
                                                                i + 1, dt.Rows[i]["学生姓名"].ToString());
                    return false;
                }
                if (corId == -1)
                {
                    this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,不存在‘{1}’该课程。<span>",
                                                                i + 1, dt.Rows[i]["课程"].ToString());
                    return false;
                }

                if (BLL.Utils.GetMark(dt.Rows[i]["学生姓名"].ToString(),dt.Rows[i]["课程"].ToString()))
                {
                     this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,该{1}的{2}成绩已存在。<span>",
                                                                i + 1, dt.Rows[i]["学生姓名"].ToString(),dt.Rows[i]["课程"].ToString());
                    return false;
                }

            }

            return true;
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            UpModel();
            btnSubmit.Enabled = false;
            btnSubmit.Visible = false;
        }
        private void UpModel()
        {
            DataTable dt = ViewState["table"] as DataTable;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var mark = new Model.Mark();
                mark.StudentId=Eva.BLL.Utils.GetStuIdByName( dt.Rows[i]["学生姓名"].ToString());
                mark.CourseId = Eva.BLL.Utils.GetCourseIdByName(dt.Rows[i]["课程"].ToString());
                mark.Score=int.Parse(dt.Rows[i]["成绩"].ToString());
                mark.AcademicYear=int.Parse(dt.Rows[i]["学年"].ToString());
                mark.SchoolTerm=int.Parse(dt.Rows[i]["学期"].ToString());
                mark.Gpa = Eva.BLL.Utils.GetGpa(int.Parse(dt.Rows[i]["成绩"].ToString()));

                markBll.Add(mark);
	
               
            }
            MessageBox.Show(this, "上传成功！");
        }
    }
}