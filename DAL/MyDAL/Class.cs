using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
	/// <summary>
	/// 数据访问类:Class
	/// </summary>
	public partial class Class
	{
        public DataSet GetAllListWithCollegeId()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Class.Id,Class.Name,MajorId,CollegeId ");
            strSql.Append(" FROM Class,Major ");
            strSql.Append(" where Class.MajorId=Major.Id");
           
            return DbHelperSQL.Query(strSql.ToString());
        }

       
        
    }
}

