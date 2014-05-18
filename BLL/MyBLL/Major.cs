using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
    /// <summary>
    /// Major
    /// </summary>
    public partial class Major
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eva.Model.Major> GetModelListByCollegeId(String id)
        {
            DataSet ds = dal.GetList(" CollegeId = " + id);
            return DataTableToList(ds.Tables[0]);
        }
     
    }
}

