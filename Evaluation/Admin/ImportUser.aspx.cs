using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Eva.BLL;
using System.IO;
using System.Data;
using Maticsoft.Common;

namespace Eva.Evaluation.Admin
{
    public partial class ImportUser : System.Web.UI.Page
    {
        BLL.WebUser userBll = BLLFactory.GetWebUserBLLInstance();
        BLL.College collegeBll = BLLFactory.GetCollegeBLLInstance();
        BLL.Major majorBll = BLLFactory.GetMajorBLLInstance();
        BLL.Class classBll = BLLFactory.GetClassBLLInstance();
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
                int collegeId = BLL.Utils.GetCollegeIdByName(dt.Rows[i]["学院"].ToString());
                int majorId = BLL.Utils.GetMajorIdByName(dt.Rows[i]["学院"].ToString(), dt.Rows[i]["专业"].ToString());
                int classId = BLL.Utils.GetClassIdByName(dt.Rows[i]["学院"].ToString(), dt.Rows[i]["专业"].ToString(), dt.Rows[i]["班级"].ToString());

                if (collegeId == -1)
                {
                    this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,本协会不存在‘{1}’这个学院。<span>",
                                                                i + 1, dt.Rows[i]["学院"].ToString());
                    return false;
                }
                if (majorId == -1)
                {
                    this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,不存在‘{1}’这个专业。<span>",
                                                                i + 1, dt.Rows[i]["专业"].ToString());
                    return false;
                }

                if (classId == -1)
                {
                    this.Upload_info.Text += string.Format("<br/><span style='color:red;'>表格第{0}行,不存在‘{1}’这个班级。<span>",
                                                               i + 1, dt.Rows[i]["班级"].ToString());
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

                var user = new Model.WebUser();

                user.Name = StringUtil.ClearString(dt.Rows[i]["姓名"].ToString());
                user.IdCard = StringUtil.ClearString(dt.Rows[i]["身份证"].ToString());
                user.CollegeId = BLL.Utils.GetCollegeIdByName(StringUtil.ClearString(dt.Rows[i]["学院"].ToString()));
                user.MajorId = BLL.Utils.GetMajorIdByName(StringUtil.ClearString(dt.Rows[i]["学院"].ToString()), StringUtil.ClearString(dt.Rows[i]["专业"].ToString()));
                user.ClassId = BLL.Utils.GetClassIdByName(StringUtil.ClearString(dt.Rows[i]["学院"].ToString()), StringUtil.ClearString(dt.Rows[i]["专业"].ToString()), StringUtil.ClearString(dt.Rows[i]["班级"].ToString()));
                user.Sex = StringUtil.ClearString(dt.Rows[i]["性别"].ToString());
                user.Address = StringUtil.ClearString(dt.Rows[i]["联系地址"].ToString());
                user.Phone = StringUtil.ClearString(dt.Rows[i]["电话"].ToString());

                userBll.Add(user);

            }

            MessageBox.Show(this, "上传成功");
        }
    }
}