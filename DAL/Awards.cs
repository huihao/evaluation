using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
	/// <summary>
	/// 数据访问类:Awards
	/// </summary>
	public partial class Awards
	{
		public Awards()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Eva.Model.Awards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Awards(");
			strSql.Append("Name,Grade,Score,StudentId,AcademicYear,SchoolTerm,IsCheck,Total)");
			strSql.Append(" values (");
			strSql.Append("@Name,@Grade,@Score,@StudentId,@AcademicYear,@SchoolTerm,@IsCheck,@Total)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Grade", SqlDbType.NVarChar,50),
					new SqlParameter("@Score", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4),
					new SqlParameter("@IsCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@Total", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.StudentId;
			parameters[4].Value = model.AcademicYear;
			parameters[5].Value = model.SchoolTerm;
			parameters[6].Value = model.IsCheck;
			parameters[7].Value = model.Total;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Eva.Model.Awards model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Awards set ");
			strSql.Append("Name=@Name,");
			strSql.Append("Grade=@Grade,");
			strSql.Append("Score=@Score,");
			strSql.Append("StudentId=@StudentId,");
			strSql.Append("AcademicYear=@AcademicYear,");
			strSql.Append("SchoolTerm=@SchoolTerm,");
			strSql.Append("IsCheck=@IsCheck,");
			strSql.Append("Total=@Total");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@Grade", SqlDbType.NVarChar,50),
					new SqlParameter("@Score", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4),
					new SqlParameter("@IsCheck", SqlDbType.NVarChar,50),
					new SqlParameter("@Total", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Name;
			parameters[1].Value = model.Grade;
			parameters[2].Value = model.Score;
			parameters[3].Value = model.StudentId;
			parameters[4].Value = model.AcademicYear;
			parameters[5].Value = model.SchoolTerm;
			parameters[6].Value = model.IsCheck;
			parameters[7].Value = model.Total;
			parameters[8].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Awards ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Awards ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Eva.Model.Awards GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Name,Grade,Score,StudentId,AcademicYear,SchoolTerm,IsCheck,Total from Awards ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Eva.Model.Awards model=new Eva.Model.Awards();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"]!=null && ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Grade"]!=null && ds.Tables[0].Rows[0]["Grade"].ToString()!="")
				{
					model.Grade=ds.Tables[0].Rows[0]["Grade"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Score"]!=null && ds.Tables[0].Rows[0]["Score"].ToString()!="")
				{
					model.Score=ds.Tables[0].Rows[0]["Score"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StudentId"]!=null && ds.Tables[0].Rows[0]["StudentId"].ToString()!="")
				{
					model.StudentId=int.Parse(ds.Tables[0].Rows[0]["StudentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AcademicYear"]!=null && ds.Tables[0].Rows[0]["AcademicYear"].ToString()!="")
				{
					model.AcademicYear=int.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SchoolTerm"]!=null && ds.Tables[0].Rows[0]["SchoolTerm"].ToString()!="")
				{
					model.SchoolTerm=int.Parse(ds.Tables[0].Rows[0]["SchoolTerm"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IsCheck"]!=null && ds.Tables[0].Rows[0]["IsCheck"].ToString()!="")
				{
					model.IsCheck=ds.Tables[0].Rows[0]["IsCheck"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Total"]!=null && ds.Tables[0].Rows[0]["Total"].ToString()!="")
				{
					model.Total=int.Parse(ds.Tables[0].Rows[0]["Total"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Name,Grade,Score,StudentId,AcademicYear,SchoolTerm,IsCheck,Total ");
			strSql.Append(" FROM Awards ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Name,Grade,Score,StudentId,AcademicYear,SchoolTerm,IsCheck,Total ");
			strSql.Append(" FROM Awards ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Awards ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Awards T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Awards";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

