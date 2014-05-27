/**  版本信息模板在安装目录下，可自行修改。
* Mark.cs
*
* 功 能： N/A
* 类 名： Mark
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/27 2:22:16   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
	/// <summary>
	/// 数据访问类:Mark
	/// </summary>
	public partial class Mark
	{
		public Mark()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Eva.Model.Mark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Mark(");
			strSql.Append("CourseId,StudentId,EvalutionId,Score,BonusPoint,AcademicYear,SchoolTerm,CheckStep,Reason,Gpa)");
			strSql.Append(" values (");
			strSql.Append("@CourseId,@StudentId,@EvalutionId,@Score,@BonusPoint,@AcademicYear,@SchoolTerm,@CheckStep,@Reason,@Gpa)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@EvalutionId", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Float,8),
					new SqlParameter("@BonusPoint", SqlDbType.Float,8),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4),
					new SqlParameter("@CheckStep", SqlDbType.Int,4),
					new SqlParameter("@Reason", SqlDbType.NVarChar,50),
					new SqlParameter("@Gpa", SqlDbType.Float,8)};
			parameters[0].Value = model.CourseId;
			parameters[1].Value = model.StudentId;
			parameters[2].Value = model.EvalutionId;
			parameters[3].Value = model.Score;
			parameters[4].Value = model.BonusPoint;
			parameters[5].Value = model.AcademicYear;
			parameters[6].Value = model.SchoolTerm;
			parameters[7].Value = model.CheckStep;
			parameters[8].Value = model.Reason;
			parameters[9].Value = model.Gpa;

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
		public bool Update(Eva.Model.Mark model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Mark set ");
			strSql.Append("CourseId=@CourseId,");
			strSql.Append("StudentId=@StudentId,");
			strSql.Append("EvalutionId=@EvalutionId,");
			strSql.Append("Score=@Score,");
			strSql.Append("BonusPoint=@BonusPoint,");
			strSql.Append("AcademicYear=@AcademicYear,");
			strSql.Append("SchoolTerm=@SchoolTerm,");
			strSql.Append("CheckStep=@CheckStep,");
			strSql.Append("Reason=@Reason,");
			strSql.Append("Gpa=@Gpa");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@CourseId", SqlDbType.Int,4),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@EvalutionId", SqlDbType.Int,4),
					new SqlParameter("@Score", SqlDbType.Float,8),
					new SqlParameter("@BonusPoint", SqlDbType.Float,8),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4),
					new SqlParameter("@CheckStep", SqlDbType.Int,4),
					new SqlParameter("@Reason", SqlDbType.NVarChar,50),
					new SqlParameter("@Gpa", SqlDbType.Float,8),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.CourseId;
			parameters[1].Value = model.StudentId;
			parameters[2].Value = model.EvalutionId;
			parameters[3].Value = model.Score;
			parameters[4].Value = model.BonusPoint;
			parameters[5].Value = model.AcademicYear;
			parameters[6].Value = model.SchoolTerm;
			parameters[7].Value = model.CheckStep;
			parameters[8].Value = model.Reason;
			parameters[9].Value = model.Gpa;
			parameters[10].Value = model.Id;

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
			strSql.Append("delete from Mark ");
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
			strSql.Append("delete from Mark ");
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
		public Eva.Model.Mark GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,CourseId,StudentId,EvalutionId,Score,BonusPoint,AcademicYear,SchoolTerm,CheckStep,Reason,Gpa from Mark ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Eva.Model.Mark model=new Eva.Model.Mark();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Eva.Model.Mark DataRowToModel(DataRow row)
		{
			Eva.Model.Mark model=new Eva.Model.Mark();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["CourseId"]!=null && row["CourseId"].ToString()!="")
				{
					model.CourseId=int.Parse(row["CourseId"].ToString());
				}
				if(row["StudentId"]!=null && row["StudentId"].ToString()!="")
				{
					model.StudentId=int.Parse(row["StudentId"].ToString());
				}
				if(row["EvalutionId"]!=null && row["EvalutionId"].ToString()!="")
				{
					model.EvalutionId=int.Parse(row["EvalutionId"].ToString());
				}
				if(row["Score"]!=null && row["Score"].ToString()!="")
				{
					model.Score=decimal.Parse(row["Score"].ToString());
				}
				if(row["BonusPoint"]!=null && row["BonusPoint"].ToString()!="")
				{
					model.BonusPoint=decimal.Parse(row["BonusPoint"].ToString());
				}
				if(row["AcademicYear"]!=null && row["AcademicYear"].ToString()!="")
				{
					model.AcademicYear=int.Parse(row["AcademicYear"].ToString());
				}
				if(row["SchoolTerm"]!=null && row["SchoolTerm"].ToString()!="")
				{
					model.SchoolTerm=int.Parse(row["SchoolTerm"].ToString());
				}
				if(row["CheckStep"]!=null && row["CheckStep"].ToString()!="")
				{
					model.CheckStep=int.Parse(row["CheckStep"].ToString());
				}
				if(row["Reason"]!=null)
				{
					model.Reason=row["Reason"].ToString();
				}
				if(row["Gpa"]!=null && row["Gpa"].ToString()!="")
				{
					model.Gpa=decimal.Parse(row["Gpa"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,CourseId,StudentId,EvalutionId,Score,BonusPoint,AcademicYear,SchoolTerm,CheckStep,Reason,Gpa ");
			strSql.Append(" FROM Mark ");
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
			strSql.Append(" Id,CourseId,StudentId,EvalutionId,Score,BonusPoint,AcademicYear,SchoolTerm,CheckStep,Reason,Gpa ");
			strSql.Append(" FROM Mark ");
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
			strSql.Append("select count(1) FROM Mark ");
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
			strSql.Append(")AS Row, T.*  from Mark T ");
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
			parameters[0].Value = "Mark";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

