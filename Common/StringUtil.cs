using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Security.Cryptography;

namespace Maticsoft.Common
{


    
    /// <summary>
    /// StringUtil 的摘要说明。
    /// </summary>
    public sealed class StringUtil
    {
        //public static string GetMD5Hash(String input)
        //{
        //    MD5 md5 = new MD5CryptoServiceProvider();
        //    byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
        //    char[] temp = new char[res.Length];
        //    System.Array.Copy(res, temp, res.Length);
        //    return new String(temp);
        //}
        public static string GetMD5Hash(string pwd)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(pwd);
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");
        }

        public static string ClearString(string s)
        {
            string str;
            str = s.Replace("\n", "");
            str = s.Replace(" ", "");
            return str.Trim();
        }

        public static string EncodeSpecChinese(string str)
        {
            str = str.Replace("•", "&middot;");

            return str;

        }

        public static string DecodeSpecChinese(string str)
        {
            str = str.Replace("&middot;", "•");

            return str;

        }

        /// <summary>
        /// url里有key的值，就替换为value,没有的话就追加
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ParamText"></param>
        /// <param name="ParamValue"></param>
        /// <returns></returns>
        public static string BuildUrl(string url, string ParamText, string ParamValue)
        {
            url = BuildUrl(url, "page");
            Regex reg = new Regex(string.Format("{0}=[^&]*", ParamText), RegexOptions.IgnoreCase);
            Regex reg1 = new Regex("[&]{2,}", RegexOptions.IgnoreCase);
            string _url = reg.Replace(url, "");
            //_url = reg1.Replace(_url, "");
            if (_url.IndexOf("?") == -1)
                _url += string.Format("?{0}={1}", ParamText, ParamValue);//?
            else
                _url += string.Format("&{0}={1}", ParamText, ParamValue);//&
            _url = reg1.Replace(_url, "&");
            _url = _url.Replace("?&", "?");
            return _url;
        }
        /// <summary>
        /// 判断传入日期与现在时间的差值是否符合要求，是就返回True，否就返回False
        /// </summary>
        public static bool isNew(DateTime dt,int days)
        {
            int a = DateTime.Now.CompareTo(dt);
            TimeSpan d = DateTime.Now - dt;

            if (Math.Abs(d.Days) > days)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 获取当前年份第一天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentYearFirst()
        {
            return Convert.ToDateTime(new DateTime(DateTime.Now.Year, 1, 1));    
        }

        /// <summary>
        /// 获取当前年份最后一天
        /// </summary>
        /// <returns></returns>
        public static DateTime GetCurrentYearEnd()
        {
            return Convert.ToDateTime(new DateTime(DateTime.Now.Year, 12, 31));
        }

         //根据身份证号码获得出生日期
        public static string GetBirthDay(string id)
        {
            string bir;

            if (id.Length == 18)
            {
                bir = id.Substring(6, 8);
            }
            else
            {
                bir = "19" + id.Substring(6, 6);
            }
            string yer = bir.Substring(0, 4);
            string mon = bir.Substring(4, 2);
            string day = bir.Substring(6, 2);
            string last = yer + '-' + mon + '-' + day;
            return last;
        }
    
        /// <summary>
        /// url里有key的值，就删除
        /// </summary>
        /// <param name="url"></param>
        /// <param name="ParamText"></param>
        /// <returns></returns>
        public static string BuildUrl(string url, string ParamText)
        {
            Regex reg = new Regex(string.Format("{0}=[^&]*", ParamText), RegexOptions.IgnoreCase);
            Regex reg1 = new Regex("[&]{2,}", RegexOptions.IgnoreCase);
            string _url = reg.Replace(url, "");
            _url = reg1.Replace(_url, "&");
            _url = _url.Replace("?&", "?");

            if (_url.EndsWith("&") || _url.EndsWith("?"))
                _url = _url.Substring(0, _url.Length - 1);

            return _url;
        }

        /// <summary>
        /// 添加n个换行
        /// </summary>
        /// <param name="iCount"></param>
        /// <returns></returns>
        public static string FillChangeCharaterString(int iCount)
        {
            string sReturn = "";

            for (int i = 0; i < iCount; i++)
            {
                sReturn += "\r\n";
            }

            return sReturn;
        }


        /// <summary>
        /// 后台注册脚本到前台
        /// </summary>
        /// <param name="jsList"></param>
        /// <returns></returns>
        public static string RegisterBackgroundScriptToClient(string jsList)
        {
            string sChangeLine = "\r\n";
            string sRegisterBackgroundScript = "";
            sRegisterBackgroundScript += "<script language='javascript'>" + sChangeLine;
            sRegisterBackgroundScript += "<!--" + sChangeLine;
            sRegisterBackgroundScript += jsList + sChangeLine;
            sRegisterBackgroundScript += "//-->" + sChangeLine;
            sRegisterBackgroundScript += "</script>" + sChangeLine;
            return sRegisterBackgroundScript;
        }


        /// <summary>
        /// 判断当前元素是否为空,空就跳转
        /// </summary>
        /// <param name="element"></param>
        /// <param name="page"></param>
        public static void CheckElementIsEmptyOrRederictPromptPage(string sElementValue, string sPromt, string sRedirectPromptPage, System.Web.UI.Page page)
        {
            if (sElementValue == "")
            {
                page.Response.Redirect(sRedirectPromptPage + "?Promt=" + sPromt);
            }
        }


        /// <summary>
        /// 显示　手机　号，屏蔽用***号显示某些位置
        /// 在网站上显示手机号只能显示前三位及后四位,中间的区域号码不要显示,这是业内规范。
        /// </summary>
        /// <param name="GbCode"></param>
        /// <returns></returns>
        public static string DisplayMobileInShieldState(string sMobile)
        {
            string s = "";
            if (sMobile.Length >= 11)
            {
                //0123456789AB
                s = sMobile.Substring(0, 3) + "****" + sMobile.Substring(sMobile.Length - 4, 4);
            }
            else
            {
                s = sMobile.Substring(0, 3) + "*******";
            }
            return s;
        }

        public static string getUTF8(string GbCode)
        {
            Encoding UTF8 = Encoding.UTF8;
            Encoding Gb2312 = Encoding.GetEncoding("gb2312");
            byte[] gb2312Bytes = Gb2312.GetBytes(GbCode);
            byte[] UTF8Bytes = System.Text.Encoding.Convert(Gb2312, UTF8, gb2312Bytes);
            char[] UTF8Chars = UTF8.GetChars(UTF8Bytes);
            return new string(UTF8Chars);
        }

        #region  字符编码处理

        /// <summary>
        /// 字符串处理gb2312 to utf-8
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        public static string ConvertGB2312ToUtf8(string sInputGB2312)
        {
            //			Encoding gb2312=Encoding.GetEncoding("gb2312");
            //			Encoding UTF8=Encoding.UTF8;
            //			byte[] gb2312Bytes=gb2312.GetBytes(sInputGB2312);
            //			byte[] UTF8Bytes =gb2312.GetEncoder().Convert(gb2312,UTF8,gb2312Bytes);
            //			char[] UTF8Chars=UTF8.GetChars(UTF8Bytes);
            //			return new string(UTF8Chars);
            //
            //			return System.Text.Encoding.UTF8.GetString(System.Text.Encoding.GetEncoding("gb2312").GetBytes(sInputGB2312));
            //
            //			byte[] bytg= System.Text.Encoding.GetEncoding("GB2312").GetBytes(sInputGB2312);
            //			byte[] byt8= System.Text.Encoding.Convert(System.Text.Encoding.GetEncoding("GB2312"), System.Text.Encoding.UTF8,bytg);
            //			return System.Text.Encoding.UTF8.GetString(byt8);

            //return System.Web.HttpUtility.UrlEncode(sInputGB2312);
            //return GetTargetEncodeingResponse(sInputGB2312);

            return System.Web.HttpUtility.UrlPathEncode(sInputGB2312);//urlencode就是utf-8
        }

        /// <summary>
        ///  字符串处理utf-8 to gb2312 
        /// </summary>
        /// <param name="sInput"></param>
        /// <returns></returns>
        public static string ConvertUtf8ToGB2312(string sInputUTF8Code)
        {
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            Encoding UTF8 = Encoding.UTF8;
            byte[] UTF8Bytes = UTF8.GetBytes(sInputUTF8Code);
            byte[] gb2312Bytes = UTF8Encoding.Convert(UTF8, gb2312, UTF8Bytes);
            char[] gb2312Chars = gb2312.GetChars(gb2312Bytes);
            return new string(gb2312Chars);
        }

        #endregion

        //		/// <summary>
        //		/// 向目标url请求 Get请求
        //		/// </summary>
        //		/// <param name="url"></param>
        //		/// <param name="paramList"></param>
        //		/// <returns></returns>
        //		public static string GetTargetEncodeingResponse(string content) 
        //		{
        //			String paramList="content="+content;
        //			return WebRequestUtil.GetResponseFromTargetUrlPageWithGetMethodWithUtf8Encoding(NewLencity.Framework.Configuration.WebSiteUrlNavigaterConfig.Asp_DoGb2312ToUtf8_Page, paramList) ;
        //		}



        /** bluesnail
        private string getGB2312(string UTF8Code)
        {
            Encoding gb2312=Encoding.GetEncoding("gb2312");
            Encoding UTF8=Encoding.UTF8;
            byte[] UTF8Bytes=UTF8.GetBytes(UTF8Code);
            byte[] gb2312Bytes =UTF8Encoding.Convert(UTF8,gb2312,UTF8Bytes);
            char[] gb2312Chars=gb2312.GetChars(gb2312Bytes);
            return new string(gb2312Chars);
        }
        **/



        /// <summary>
        /// 检查输入的期间定义是否ok
        /// 判断原则: 1-20,21-40,41-80,81-100,101+
        /// 用,号隔开，在最后一个前是连续的元素，用+号结束
        /// </summary>
        /// <param name="sQuantityIndex"></param>
        /// <returns></returns>
        public static bool CheckPeriodIndexIsValid(string sQuantityIndex)
        {
            sQuantityIndex = sQuantityIndex.Trim();
            if (sQuantityIndex.Substring(0, 1) != "1")//1 开头
            {
                return false;
            }

            if (sQuantityIndex.Substring(sQuantityIndex.Length - 1, 1) != "+")//+ 结尾
            {
                return false;
            }

            string[] sQuantityIndexArray = sQuantityIndex.Split(',');
            for (int i = 0; i < sQuantityIndexArray.Length; i++)
            {
                if (i < (sQuantityIndexArray.Length - 2))//倒数第2个以前
                {
                    try
                    {
                        int iFindElement1SignLocation = sQuantityIndexArray[i].IndexOf("-");
                        string sFindElement1EndIndex = sQuantityIndexArray[i].Substring(iFindElement1SignLocation + 1, sQuantityIndexArray[i].Length - iFindElement1SignLocation - 1);
                        int iFindElement2SignLocation = sQuantityIndexArray[i + 1].IndexOf("-");
                        string sFindElement2BeginIndex = sQuantityIndexArray[i + 1].Substring(0, iFindElement2SignLocation);

                        if ((int.Parse(sFindElement1EndIndex) + 1) != int.Parse(sFindElement2BeginIndex))
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
                else if (i == (sQuantityIndexArray.Length - 2))//倒数第二个
                {
                    try
                    {
                        int iFindElement1SignLocation = sQuantityIndexArray[i].IndexOf("-");
                        string sFindElement1EndIndex = sQuantityIndexArray[i].Substring(iFindElement1SignLocation + 1, sQuantityIndexArray[i].Length - iFindElement1SignLocation - 1);
                        int iFindElement2SignLocation = sQuantityIndexArray[i + 1].IndexOf("+");
                        string sFindElement2BeginIndex = sQuantityIndexArray[i + 1].Substring(0, iFindElement2SignLocation);

                        if ((int.Parse(sFindElement1EndIndex) + 1) != int.Parse(sFindElement2BeginIndex))
                        {
                            return false;
                        }
                    }
                    catch
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 生成n位数字随机数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GenNumberTypeRandom(int count)
        {
            Random TempInt = new Random();
            string outstr = "";
            string tempStr1 = "";
            for (int i = 1; i <= count; i++)
            {
                tempStr1 = tempStr1 + "0";
            }
            tempStr1 = "1" + tempStr1;
            int tempInt2 = TempInt.Next(int.Parse(tempStr1));
            outstr = tempInt2.ToString();
            int j = tempInt2.ToString().Length;
            while (j < count)
            {
                outstr = outstr + "0";
                j++;
            }

            return outstr;
        }


        /// <summary>
        ///  生成n位字符类型随机数据
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GenStringTypeRandom(int count)
        {
            System.Random TempInt = new Random((unchecked((int)DateTime.Now.Ticks)));
            string ran = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (TempInt.Next().ToString(), "MD5").ToLower().Substring(0, count);
            return ran;
        }

        /// <summary>
        /// 获得指定长度的内容
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetSpecificSizeString(string str, int iLength)
        {
            if (str.Length > iLength)
                return str.Substring(0, iLength - 2) + "..";
            else
                return str;
        }

        /// <summary>
        /// 生成给定数量的空格
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string NumSpace(int count)
        {
            string outString = String.Empty;

            for (int i = 1; i <= count; i++)
            {
                outString = outString + " ";
            }

            return outString;
        }

        /// <summary>
        /// 给指定的支付串用空格填充到指定的长度
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="toStringCount"></param>
        /// <returns></returns>
        public static string FillSpaceToFitString(string inString, int toStringCount)
        {
            int inStringLength = inString.Length;

            if (inStringLength < toStringCount)
            {
                inString = inString + NumSpace(toStringCount - inStringLength);
            }

            return inString;
        }


        /// <summary>
        /// 生成给定数量的的"0"
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string NumZero(int count)
        {
            string outString = String.Empty;

            for (int i = 1; i <= count; i++)
            {
                outString = outString + "0";
            }

            return outString;
        }


        /// <summary>
        /// 给某个字符串左添加"0"填充到指定的长度
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="toStringCount"></param>
        /// <returns></returns>
        public static string FillZeroToFitString(string inString, int toStringCount)
        {
            int inStringLength = inString.Length;

            if (inStringLength < toStringCount)
            {
                inString = NumZero(toStringCount - inStringLength) + inString;
            }

            return inString;
        }


        //		/// <summary>
        //		///  给某个字符串添加指定的字符填充到指定的长度
        //		/// </summary>
        //		/// <param name="inString"></param>
        //		/// <param name="toStringCount"></param>
        //		/// <param name="fillChar"></param>
        //		/// <returns></returns>
        //		public static string FillCharToFitString(string inString,int toStringCount,int fillChar)
        //		{
        //			int inStringLength=inString.Length;
        //			if(inStringLength<toStringCount)
        //			{
        //				for(int i=1;i<=(toStringCount-inStringLength);i++)
        //				{
        //					inString=fillChar+inString ;
        //				}
        //			}
        //			return inString;
        //		}




        /// <summary>
        ///  给某个字符串添加指定的字符填充到指定的长度
        /// </summary>
        /// <param name="inString"></param>
        /// <param name="toStringCount"></param>
        /// <param name="fillChar"></param>
        /// <returns></returns>
        public static string FillCharToFitString(string inString, int toStringCount, string fillChar)
        {
            int inStringLength = inString.Length;
            if (inStringLength < toStringCount)
            {
                for (int i = 1; i <= (toStringCount - inStringLength); i++)
                {
                    inString = fillChar + inString;
                }
            }
            return inString;
        }






        /// <summary>
        /// 检查是否包括中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckContainChinese(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] > 128)  // 表示是中文字符
                {
                    return true;
                }
                else
                {
                    i = i + 1;
                }
            }

            return false;
        }




        /// <summary>
        /// 检查是否数字或者字符
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIsNumberOrWord(string inputString)
        {
            //			if ((inputString != null) && (inputString != String.Empty)) 
            //			{
            //				inputString = inputString.Trim();
            //				for (int i=0;i<inputString.Length;i++) 
            //				{
            //					if(!char.IsLetterOrDigit(inputString,i)) 
            //						return false;
            //				}	
            //				return true;
            //			}
            //			return false;

            for (int i = 0; i < inputString.Length; i++)
            {
                char c = inputString[i];
                if ((c >= '0' && c <= '9') || (c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {

                }
                else
                {
                    return false;
                }
            }

            return true;

        }




        /// <summary>
        /// 检查是否全部是中文
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckIsAllChinese(string str)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] < 128)
                {
                    return false;
                }
                else
                {
                    i += 1;
                }
            }

            return true;
        }

        //转换为HTML
        public static string ConvertTextToHtml(string str)
        {
            string strTemp = "";
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            //str = str.Replace("'","''");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");//空格
            str = str.Replace("\r", "<br>");//回车
            str = str.Replace("u0009", "&nbsp;&nbsp;&nbsp;&nbsp;");//TAB

            strTemp = str;

            return strTemp;
        }

        //转换为文本
        public static string ConvertHtmlToText(string str)
        {
            string strTemp = "";
            str = str.Replace("&amp;", "&");
            str = str.Replace("\t", "&nbsp;&nbsp;");
            str = str.Replace("&lt;", "<");
            str = str.Replace("\"", "'");
            str = str.Replace("&gt;", ">");
            str = str.Replace("<br>", "\r");//回车
            strTemp = str;

            return strTemp;
        }


        /// <summary>
        /// 格式化保留换行，跳位
        /// </summary>
        /// <param name="instring"></param>
        /// <returns></returns>
        public static string FormatInputString(string inputString)
        {
            return inputString.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;");
        }

        /// <summary>
        /// 去掉freetextbox中输入的非法字符，一般是javascript方面的字符
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string FormatFreeTextBoxInputString(string inputString)
        {
            //定义的非法字符
            string[] inValidString ={
									   "alert(","onload(","confirm("	
								   };
            for (int i = 0; i < inValidString.Length; i++)
            {
                inputString = inputString.Replace(inValidString[i], "****");
            }

            return inputString;
        }

        /// <summary>
        /// 恢复格式化了的字符
        /// </summary>
        /// <param name="instring"></param>
        /// <returns></returns>
        public static string RecoveryFormatedString(string inputString)
        {
            return inputString.Replace("<br>", "\n");
        }


        /// <summary>
        /// 格式化输入文本
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        public static string FormatInputText(string inputString)
        {
            return FormatInputText(inputString, 200);
        }

        /// <summary>
        /// 转化输入的非法字符
        /// </summary>
        /// <param name="inputString"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static string FormatInputText(string inputString, int maxLength)
        {
            StringBuilder retVal = new StringBuilder();

            // check incoming parameters for null or blank string
            if ((inputString != null) && (inputString != String.Empty))
            {
                inputString = inputString.Trim();

                if (inputString.Length > maxLength)
                    inputString = inputString.Substring(0, maxLength);

                for (int i = 0; i < inputString.Length; i++)
                {
                    switch (inputString[i])
                    {
                        case '"':
                            retVal.Append("&quot;");
                            break;
                        case '<':
                            retVal.Append("&lt;");
                            break;
                        case '>':
                            retVal.Append("&gt;");
                            break;
                        default:
                            retVal.Append(inputString[i]);
                            break;
                    }
                }

                retVal.Replace("'", " ");
            }

            return retVal.ToString();
        }





        /// <summary>
        /// 随机生成给定位数的字符
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GenRan(int count)
        {
            Random TempInt = new Random();
            string ran = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile
                (TempInt.Next().ToString(), "MD5").ToLower().Substring(0, count);
            return ran;
        }



        /// <summary>
        /// 格式化标题
        /// </summary>
        public static String FormatCaption(String cont)
        {
            StringBuilder str = new StringBuilder(cont.Trim());

            str = str.Replace("'", "\"");
            str = str.Replace("\x0020", "&nbsp;");

            return str.ToString();
        }

        /// <summary>
        /// 格式化内容
        /// </summary>
        public static String FormatContent(String cont)
        {
            StringBuilder str = new StringBuilder(cont.Trim());

            str = str.Replace("\r\n", "<br>");
            str = str.Replace("'", "\"");
            str = str.Replace("\x0020", "&nbsp;");

            return "&nbsp;&nbsp;&nbsp;&nbsp;" + str.ToString();
        }

        /// <summary>
        /// 格式化资料来源
        /// </summary>
        public static String FormatSource(String cont)
        {
            StringBuilder str = new StringBuilder(cont.Trim());

            str = str.Replace("\r\n", "<br>");
            str = str.Replace("'", "\"");
            str = str.Replace("\x0020", "&nbsp;");

            return str.ToString();
        }

        /// <summary>
        /// 访问权限提示
        /// </summary>
        public static void AccessAlert(Page sender, String message)
        {
            sender.Response.Write("<script language='javascript'>alert('" + message + "');history.go(-1);</script>");
        }

        /// <summary>
        /// 处理输入的字符串
        /// </summary>
        public static String DealInput(String exp)
        {
            StringBuilder str = new StringBuilder(exp);

            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("'", "\"");

            return str.ToString();
        }

        /// <summary>
        /// 将 HTML 显示为文本,Html格式失效
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string HtmlConvertAsText(string str)
        {
            string strTemp = "";
            str = str.Replace("&", "&amp;");
            str = str.Replace("<", "&lt;");
            //str = str.Replace("'","''");
            str = str.Replace(">", "&gt;");
            str = str.Replace(" ", "&nbsp;");//空格
            str = str.Replace("\r", "<br>");//回车
            str = str.Replace("u0009", "&nbsp;&nbsp;&nbsp;&nbsp;");//TAB

            strTemp = str;

            return strTemp;
        }

        /// <summary>
        /// 将文本  转换为 HTML
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string TextConvertAsHtml(string str)
        {
            string strTemp = "";
            str = str.Replace("&amp;", "&");
            str = str.Replace("&lt;", "<");
            str = str.Replace("\"", "'");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&nbsp;", " ");//空格
            str = str.Replace("<br>", "\r");//回车
            str = str.Replace("&nbsp;&nbsp;&nbsp;&nbsp;", "u0009");//TAB

            strTemp = str;

            return strTemp;
        }

        /// <summary>
        /// 将字符格式化成指定长度
        /// </summary>
        /// <param name="str">原始字符</param>
        /// <param name="length">指定长度</param>
        /// <returns>指定长度的字符串</returns>
        public static string FormatStringLength(string str, int length, string filledString)
        {
            byte[] b = System.Text.Encoding.Default.GetBytes(str);
            int sourceLength = b.Length;
            if (sourceLength < length)
            {
                string tmpFilledString = string.Empty;
                tmpFilledString = tmpFilledString.PadLeft(length - sourceLength, ' ');
                tmpFilledString = tmpFilledString.Replace(" ", filledString);
                str += tmpFilledString;
            }
            else if (sourceLength > length)
            {
                byte[] newc = new byte[length - 2];
                bool isChinese = false;
                for (int i = 0; i < length - 2; i++)
                {
                    newc[i] = b[i];
                    if (b[i] > 128)  // 表示是中文字符
                    {
                        isChinese = !isChinese;
                    }
                }

                if (isChinese)
                {
                    newc[length - 3] = Convert.ToByte('.');
                }


                str = System.Text.Encoding.Default.GetString(newc);
                str += "..";
            }

            return str;
        }



        //		/// <summary>
        //		/// 获得字符串的拼音排顺序index(A B C D E F G H I J K L M N O P Q R S T U V W X Y Z)
        //		/// </summary>
        //		/// <param name="str"></param>
        //		/// <returns></returns>
        //		public static string GetPYIndexOfString(string str)
        //		{
        //			//阿-176 -->A-65    176-65=111
        //			//比-177 -->B-66    177-66=111
        //
        //			if(str.Length==0)
        //				return "A";
        //
        //			byte[] b = System.Text.Encoding.Default.GetBytes(str); 
        //			 
        //			string sPYIndex="A";
        //			if (b[0]>128)  //中文
        //			{ 
        //				string sTemp=b[0].ToString();
        //				sPYIndex=GetPYIndexOfIntValue(int.Parse(b[0].ToString())-111);	;	 
        //			}
        //			else  //英文
        //			{
        //				sPYIndex=GetPYIndexOfIntValue(int.Parse(b[0].ToString()));	 
        //			}
        //
        //			return sPYIndex;
        //		}

        //		/// <summary>
        //		/// 获得整数值的字符索引
        //		/// </summary>
        //		/// <param name="iIntValue"></param>
        //		/// <returns></returns>
        //		public static string GetPYIndexOfIntValue(int iIntValue)
        //		{
        //			string sPYIndex="A";
        //			switch(iIntValue)
        //			{
        //				case 65:sPYIndex="A";break;
        //				case 66:sPYIndex="B";break;
        //				case 67:sPYIndex="C";break;
        //				case 68:sPYIndex="D";break;
        //				case 69:sPYIndex="E";break;
        //				case 70:sPYIndex="F";break;
        //				case 71:sPYIndex="G";break;
        //				case 72:sPYIndex="H";break;
        //				case 73:sPYIndex="I";break;
        //				case 74:sPYIndex="J";break;
        //				case 75:sPYIndex="K";break;
        //				case 76:sPYIndex="L";break;
        //				case 77:sPYIndex="M";break;
        //				case 78:sPYIndex="N";break;
        //				case 79:sPYIndex="O";break;
        //				case 80:sPYIndex="P";break;
        //				case 81:sPYIndex="Q";break;
        //				case 82:sPYIndex="R";break;
        //				case 83:sPYIndex="S";break;
        //				case 84:sPYIndex="T";break;
        //				case 85:sPYIndex="U";break;
        //				case 86:sPYIndex="V";break;
        //				case 87:sPYIndex="W";break;
        //				case 88:sPYIndex="X";break;
        //				case 89:sPYIndex="Y";break;
        //				case 90:sPYIndex="Z";break;
        //			}
        //			return sPYIndex;
        //		}



        /// <summary>
        /// 拼音值数组
        /// </summary>
        private static int[] pyvalue = new int[]{-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,-20032,-20026,  
													  -20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,-19756,-19751,-19746,-19741,-19739,-19728,  
													  -19725,-19715,-19540,-19531,-19525,-19515,-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,  
													  -19261,-19249,-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,-19003,-18996,  
													  -18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,-18731,-18722,-18710,-18697,-18696,-18526,  
													  -18518,-18501,-18490,-18478,-18463,-18448,-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183,  
													  -18181,-18012,-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,-17733,-17730,  
													  -17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,-17468,-17454,-17433,-17427,-17417,-17202,  
													  -17185,-16983,-16970,-16942,-16915,-16733,-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,  
													  -16452,-16448,-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,-16212,-16205,  
													  -16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,-15933,-15920,-15915,-15903,-15889,-15878,  
													  -15707,-15701,-15681,-15667,-15661,-15659,-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,  
													  -15408,-15394,-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,-15149,-15144,  
													  -15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,-14941,-14937,-14933,-14930,-14929,-14928,  
													  -14926,-14922,-14921,-14914,-14908,-14902,-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,  
													  -14663,-14654,-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,-14170,-14159,  
													  -14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,-14109,-14099,-14097,-14094,-14092,-14090,  
													  -14087,-14083,-13917,-13914,-13910,-13907,-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,  
													  -13611,-13601,-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,-13340,-13329,  
													  -13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,-13068,-13063,-13060,-12888,-12875,-12871,  
													  -12860,-12858,-12852,-12849,-12838,-12831,-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,  
													  -12320,-12300,-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,-11781,-11604,  
													  -11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,-11055,-11052,-11045,-11041,-11038,-11024,  
													  -11020,-11019,-11018,-11014,-10838,-10832,-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,  
													  -10329,-10328,-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254};

        /// <summary>
        /// 拼音字符
        /// </summary>
        private static string[] pystr = new string[]{"a","ai","an","ang","ao","ba","bai","ban","bang","bao","bei","ben","beng","bi","bian","biao",  
														  "bie","bin","bing","bo","bu","ca","cai","can","cang","cao","ce","ceng","cha","chai","chan","chang","chao","che","chen",  
														  "cheng","chi","chong","chou","chu","chuai","chuan","chuang","chui","chun","chuo","ci","cong","cou","cu","cuan","cui",  
														  "cun","cuo","da","dai","dan","dang","dao","de","deng","di","dian","diao","die","ding","diu","dong","dou","du","duan",  
														  "dui","dun","duo","e","en","er","fa","fan","fang","fei","fen","feng","fo","fou","fu","ga","gai","gan","gang","gao",  
														  "ge","gei","gen","geng","gong","gou","gu","gua","guai","guan","guang","gui","gun","guo","ha","hai","han","hang",  
														  "hao","he","hei","hen","heng","hong","hou","hu","hua","huai","huan","huang","hui","hun","huo","ji","jia","jian",  
														  "jiang","jiao","jie","jin","jing","jiong","jiu","ju","juan","jue","jun","ka","kai","kan","kang","kao","ke","ken",  
														  "keng","kong","kou","ku","kua","kuai","kuan","kuang","kui","kun","kuo","la","lai","lan","lang","lao","le","lei",  
														  "leng","li","lia","lian","liang","liao","lie","lin","ling","liu","long","lou","lu","lv","luan","lue","lun","luo",  
														  "ma","mai","man","mang","mao","me","mei","men","meng","mi","mian","miao","mie","min","ming","miu","mo","mou","mu",  
														  "na","nai","nan","nang","nao","ne","nei","nen","neng","ni","nian","niang","niao","nie","nin","ning","niu","nong",  
														  "nu","nv","nuan","nue","nuo","o","ou","pa","pai","pan","pang","pao","pei","pen","peng","pi","pian","piao","pie",  
														  "pin","ping","po","pu","qi","qia","qian","qiang","qiao","qie","qin","qing","qiong","qiu","qu","quan","que","qun",  
														  "ran","rang","rao","re","ren","reng","ri","rong","rou","ru","ruan","rui","run","ruo","sa","sai","san","sang",  
														  "sao","se","sen","seng","sha","shai","shan","shang","shao","she","shen","sheng","shi","shou","shu","shua",  
														  "shuai","shuan","shuang","shui","shun","shuo","si","song","sou","su","suan","sui","sun","suo","ta","tai",  
														  "tan","tang","tao","te","teng","ti","tian","tiao","tie","ting","tong","tou","tu","tuan","tui","tun","tuo",  
														  "wa","wai","wan","wang","wei","wen","weng","wo","wu","xi","xia","xian","xiang","xiao","xie","xin","xing",  
														  "xiong","xiu","xu","xuan","xue","xun","ya","yan","yang","yao","ye","yi","yin","ying","yo","yong","you",  
														  "yu","yuan","yue","yun","za","zai","zan","zang","zao","ze","zei","zen","zeng","zha","zhai","zhan","zhang",  
														  "zhao","zhe","zhen","zheng","zhi","zhong","zhou","zhu","zhua","zhuai","zhuan","zhuang","zhui","zhun","zhuo",  
														  "zi","zong","zou","zu","zuan","zui","zun","zuo"};


        /// <summary>
        /// 转换中文为拼音
        /// </summary>
        /// <param name="chrstr"></param>
        /// <returns></returns>
        public static string ConvertChineseToPy(string chrstr)
        {
            byte[] array = new byte[2];
            string returnstr = "";
            int chrasc = 0;
            int i1 = 0;
            int i2 = 0;
            char[] nowchar = chrstr.ToCharArray();
            for (int j = 0; j < nowchar.Length; j++)
            {
                array = System.Text.Encoding.Default.GetBytes(nowchar[j].ToString());
                i1 = (short)(array[0]);
                i2 = (short)(array[1]);
                chrasc = i1 * 256 + i2 - 65536;
                if (chrasc > 0 && chrasc < 160)
                {
                    returnstr += nowchar[j];
                }
                else
                {
                    for (int i = (pyvalue.Length - 1); i >= 0; i--)
                    {
                        if (pyvalue[i] <= chrasc)
                        {
                            returnstr += pystr[i];
                            break;
                        }
                    }
                }
            }
            return returnstr;
        }



        /// <summary>
        /// 获得字符串的拼音排顺序index(A B C D E F G H I J K L M N O P Q R S T U V W X Y Z)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPYIndexOfString(string str)
        {
            if (str.Length == 0) return "A";
            byte[] b = System.Text.Encoding.Default.GetBytes(str);

            string sPYIndex = "A";
            if (b[0] > 128)  //中文
            {
                if (ConvertChineseToPy(str).Length > 0)
                    sPYIndex = ConvertChineseToPy(str).Substring(0, 1).ToUpper();
                else
                    sPYIndex = "A";
            }
            else  //英文
            {
                sPYIndex = str.Substring(0, 1).ToUpper();
            }

            return sPYIndex;
        }


        /// <summary> 
        /// 数字随机数 
        /// </summary> 
        /// <param name="n">生成长度</param> 
        /// <returns></returns> 
        public static string RandNum(int n)
        {
            char[] arrChar = new char[] {'2', '3', '4', '5', '6', '7', '8', '9','a','b','c',
             'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'm','n','p','q','r','s','t','u','v','w',
             'x','y','z',
             '$', '%', '*','#'};
            StringBuilder num = new StringBuilder();
            Random rnd = new Random(DateTime.Now.Millisecond);
            System.Threading.Thread.Sleep(100);
            for (int i = 0; i < n; i++)
            {
                num.Append(arrChar[rnd.Next(0, 34)].ToString());
            }
            return num.ToString();
        }


    }
}
