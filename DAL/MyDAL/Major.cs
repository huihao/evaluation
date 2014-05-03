using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
	/// <summary>
	/// 数据访问类:Major
	/// </summary>
	public partial class Major
	{
        public Eva.Model.Major GetModelByCollegeId(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,Name,CollegeId from Major ");
            strSql.Append(" where CollegeId=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;

            Eva.Model.Major model = new Eva.Model.Major();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CollegeId"] != null && ds.Tables[0].Rows[0]["CollegeId"].ToString() != "")
                {
                    model.CollegeId = int.Parse(ds.Tables[0].Rows[0]["CollegeId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }
	}
}

