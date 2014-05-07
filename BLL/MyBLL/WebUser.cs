using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
    /// <summary>
    /// WebUser
    /// </summary>
    public partial class WebUser
    {

        public DataSet GetStudents()
        {
            string sql = " StudentId is NOT NULL ";
            return dal.GetList(sql);
        }
    }
}

