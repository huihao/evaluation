using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
    /// <summary>
    /// Class
    /// </summary>
    public partial class Class
    {
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Eva.Model.Class> GetModelListByMajorId(string id)
        {
            DataSet ds = dal.GetList(" MajorId= " + id);
            return DataTableToList(ds.Tables[0]);
        }
        public DataSet GetAllListWithCollegeId()
        {
            return dal.GetAllListWithCollegeId();
        }
       
    }
}

