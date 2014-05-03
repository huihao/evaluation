using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
    /// <summary>
    /// Mark
    /// </summary>
    public partial class Mark
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

