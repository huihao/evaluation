/**  版本信息模板在安装目录下，可自行修改。
* Awards.cs
*
* 功 能： N/A
* 类 名： Awards
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/27 2:22:13   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
	/// <summary>
	/// Awards
	/// </summary>
	public partial class Awards
	{
        public DataSet GetListByStudentId(int id, string year = null, string term = null)
        {
            string sql = " StudentID = " + id;
            if (!string.IsNullOrEmpty(year))
            {
                sql += " and AcademicYear = " + year;
                if (!string.IsNullOrEmpty(term))
                {
                    sql += " and SchoolTerm = " + term;
                }
            }

            return dal.GetList(sql);
        }
	}
}

