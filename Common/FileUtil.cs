using System;
using System.IO;
using System.Web.UI.WebControls;

namespace Maticsoft.Common
{
    /// <summary>
    /// FileUtil 的摘要说明。
    /// </summary>
    public class FileUtil
    {
        public FileUtil()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        /// <summary>
        /// 在当前文件夹下建用月份命名的文件夹
        /// </summary>
        /// <param name="sCurrentFolder"></param>
        /// <param name="dtDateTime"></param>
        /// <returns></returns>
        public static string CreateCurrentDateFolder(string sCurrentFolder, DateTime dtDateTime, bool AddDateFile = true)
        {
            if (!Directory.Exists(sCurrentFolder))
            {
                Directory.CreateDirectory(sCurrentFolder);
            }

            #region 获取保存文件目录
            //考虑到系统IO的性质，每月建立一个文件夹是个好办法
            string sDateFolderString = dtDateTime.ToString("yyyyMM");//"当前月"命名的文件夹

            string folder = sCurrentFolder + "\\" + sDateFolderString;
            if (!AddDateFile)
            {
                folder = sCurrentFolder;
            }
            if (!Directory.Exists(folder))
            {
                try
                {
                    DirectoryInfo theDir = new DirectoryInfo(sCurrentFolder);
                    theDir.CreateSubdirectory(sDateFolderString);

                }
                catch (Exception ex)
                {
                    //创建文件夹失败
                    throw ex;
                }

            }
            #endregion

            return folder + "\\";
        }

        /// <summary>
        ///  检查文件类型是否有效
        /// </summary>
        /// <param name="extendName"></param>
        /// <returns></returns>
        public static bool CheckValidExt(string extendName)
        {
            bool isValid = false;
            extendName = extendName.ToLower();
            string[] extends = Definited.AllowUploadFileExtendName.Split('|');
            foreach (string extend in extends)
            {
                if (extend == extendName)
                {
                    isValid = true;
                    break;
                }
            }
            return isValid;
        }


        /// <summary>
        /// 检查文件名是否是Excel
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CheckExcelExt(string filename)
        {
            string extension = Path.GetExtension(filename);

            return extension.ToLower() == ".xls" ? true : false;

        }
        /// <summary>
        /// 检查文件名是否是Jpg
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CheckJpgExt(string filename)
        {
            string extension = Path.GetExtension(filename);

            return extension.ToLower() == ".jpg" ? true : false;

        }
        /// <summary>
        /// 检查文件名是否是Word
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CheckWordExt(string filename)
        {
            string extension = Path.GetExtension(filename);

            return (extension.ToLower() == ".doc" || extension.ToLower() == ".docx") ? true : false;

        }
        /// <summary>
        /// 获取带有时间串的文件名
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string GetFileNameWithDateTime(string pre, string ext)
        {
            //如果pre里带有扩展名，则去掉扩展名

            if (pre.Contains("."))
            {
                pre = pre.Split('.')[0];
            }

            return string.Format("{0}{1}{2}", string.Empty, DateTime.Now.ToString("yyyyMMddhhmmss"), ext);
        }
        /// <summary>
        /// 获取带有ID的图片名
        /// </summary>
        /// <param name="pre"></param>
        /// <param name="ext"></param>
        /// <returns></returns>
        public static string GetFileNameWithID(int id, string ext)
        {
            return string.Format("{0}{1}", id, ext);
        }


        #region 转换文件的大小
        /// <summary>
        /// 转换文件的大小为相对合理的格式显示
        /// Turn file size into a readability format.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetFileSizeFormatString(double size)
        {
            string sizeString;

            if (size >= 1024 * 1024)
            {
                sizeString = (Math.Round(size / 1048576, 2) + " m");
            }
            else if (size >= 1024)
            {
                sizeString = (Math.Round(size / 1024, 2) + " k");
            }
            else
            {
                sizeString = (size + " bytes");
            }

            return sizeString;
        }

        /// <summary>
        /// 转换文件的大小为相对合理的格式显示
        /// Turn file size into a readability format.
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public static string GetFileSizeFormatString(int isize)
        {
            double size = (double)isize;
            string sizeString;

            if (size >= 1024 * 1024)
            {
                sizeString = (Math.Round(size / 1048576, 2) + " M");
            }
            else if (size >= 1024)
            {
                sizeString = (Math.Round(size / 1024, 2) + " K");
            }
            else
            {
                sizeString = (size + " bytes");
            }

            return sizeString;
        }
        #endregion

        #region 文件名
        /// <summary>
        /// 随机文件名
        /// </summary>
        /// <returns></returns>
        public static string MakeFileName(DateTime dt)
        {
            string fname = dt.ToString("yyyyMMddhhmmss");
            //fname = fname.Replace("-","");
            fname = fname.Replace(" ", "");
            fname = fname.Replace(":", "");
            fname = fname.Replace("PM", "");
            fname = fname.Replace("AM", "");
            fname = fname.Replace("上午", "");
            fname = fname.Replace("下午", "");

            fname = fname + StringUtil.GenRan(2);
            return fname;
        }


        /// <summary>
        /// 随机文件名
        /// </summary>
        /// <returns></returns>
        public static string MakeFileName()
        {
            DateTime dt = System.DateTime.Now;
            string fname = dt.ToString("yyyyMMdd-hhmmss");
            //fname = fname.Replace("-","");
            fname = fname.Replace(" ", "");
            fname = fname.Replace(":", "");
            fname = fname.Replace("PM", "");
            fname = fname.Replace("AM", "");
            fname = fname.Replace("上午", "");
            fname = fname.Replace("下午", "");

            fname = fname + StringUtil.GenRan(2);
            return fname;
        }


        /// <summary>
        /// 随机文件名
        /// </summary>
        /// <returns></returns>
        public static string GeneratePhotoName(DateTime dt)
        {
            string fname = dt.ToString("yyyyMMdd-hhmmss");

            fname = fname + "-" + StringUtil.GenRan(1);
            return fname.Remove(0, 2);
            //return fname;
        }


        /// <summary>
        /// 随机文件名
        /// </summary>
        /// <returns></returns>
        public static string GenerateMusicFileName(DateTime dt)
        {
            string fname = dt.ToString("yyyyMMdd-hhmmss");

            fname = fname + "-" + StringUtil.GenRan(1);
            return fname.Remove(0, 2);
            //return fname;
        }
        #endregion

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="FileUpload1">上传控件</param>
        /// <param name="fileName">输出参数:输出文件路径</param>
        /// <param name="path">存放文件的路径</param>
        /// <returns>返回错误类型</returns>
        public static string upLoadFile(System.Web.UI.WebControls.FileUpload FileUpload1, out string fileName, string path)
        {
            fileName = "";

            if (!FileUpload1.HasFile)
            {
                return "请选择上传文件";
            }

            if (!FileUtil.CheckValidExt(FileUpload1.PostedFile.ContentType))
            {
                return "格式不被允许，请换张图片重试,允许的格式为:jpg,gif,bmp,png,zip,rar,请使用ie内核的浏览器!";
            }

            if (FileUpload1.PostedFile.ContentLength > 30000 * 1024)
            {
                return "大小超出限制(30)，请换张图片重试";
            }

            path = CreateCurrentDateFolder(path, DateTime.Now);

            //文件的名称
            fileName = GeneratePhotoName(DateTime.Now) + System.IO.Path.GetExtension(FileUpload1.FileName).ToLower();
            FileUpload1.PostedFile.SaveAs(path + "\\" + fileName);
            fileName = DateTime.Now.ToString("yyyyMM") + "/" + fileName;
            return "ok";
        }
    }

    /// <summary>
    /// 定义相关时间常量
    /// </summary>
    public class Definited
    {
        /// <summary>
        /// 项目开始运行时间
        /// </summary>
        public static DateTime ProjectRunBeginDateTime = Convert.ToDateTime("2007-12-01");
        /// <summary>
        /// 下拉控制显示全部或者所有时候的值
        /// </summary>
        public static string DropDownListItemDisplayAllValue = "ALL";
        /// <summary>
        /// web里面换行字符串
        /// </summary>
        public static string WebChangeLineString = "\r\n";
        /// <summary>
        /// 允许上传的文件扩展名。大写
        /// </summary>
        public static string AllowUploadFileExtendName = "image/gif|image/bmp|image/pjpeg|image/x-png|image/jpeg|application/octet-stream|application/x-zip-compressed";


        /// <summary>
        /// 记录记录不存在的int值
        /// </summary>
        public static int NotExist = -1;
    }
}
