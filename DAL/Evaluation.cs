using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace Eva.DAL
{
	/// <summary>
	/// 数据访问类:Evaluation
	/// </summary>
	public partial class Evaluation
	{
		public Evaluation()
		{}
		#region  Method



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Eva.Model.Evaluation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Evaluation(");
			strSql.Append("StudentId,AcademicYear,Gpa,Ave,TeacherEvaluation,SelfEvaluation,TeacherId,SchoolTerm)");
			strSql.Append(" values (");
			strSql.Append("@StudentId,@AcademicYear,@Gpa,@Ave,@TeacherEvaluation,@SelfEvaluation,@TeacherId,@SchoolTerm)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@Gpa", SqlDbType.Float,8),
					new SqlParameter("@Ave", SqlDbType.Float,8),
					new SqlParameter("@TeacherEvaluation", SqlDbType.NVarChar),
					new SqlParameter("@SelfEvaluation", SqlDbType.NVarChar),
					new SqlParameter("@TeacherId", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4)};
			parameters[0].Value = model.StudentId;
			parameters[1].Value = model.AcademicYear;
			parameters[2].Value = model.Gpa;
			parameters[3].Value = model.Ave;
			parameters[4].Value = model.TeacherEvaluation;
			parameters[5].Value = model.SelfEvaluation;
			parameters[6].Value = model.TeacherId;
			parameters[7].Value = model.SchoolTerm;

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
		public bool Update(Eva.Model.Evaluation model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Evaluation set ");
			strSql.Append("StudentId=@StudentId,");
			strSql.Append("AcademicYear=@AcademicYear,");
			strSql.Append("Gpa=@Gpa,");
			strSql.Append("Ave=@Ave,");
			strSql.Append("TeacherEvaluation=@TeacherEvaluation,");
			strSql.Append("SelfEvaluation=@SelfEvaluation,");
			strSql.Append("TeacherId=@TeacherId,");
			strSql.Append("SchoolTerm=@SchoolTerm");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@AcademicYear", SqlDbType.Int,4),
					new SqlParameter("@Gpa", SqlDbType.Float,8),
					new SqlParameter("@Ave", SqlDbType.Float,8),
					new SqlParameter("@TeacherEvaluation", SqlDbType.NVarChar),
					new SqlParameter("@SelfEvaluation", SqlDbType.NVarChar),
					new SqlParameter("@TeacherId", SqlDbType.Int,4),
					new SqlParameter("@SchoolTerm", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.StudentId;
			parameters[1].Value = model.AcademicYear;
			parameters[2].Value = model.Gpa;
			parameters[3].Value = model.Ave;
			parameters[4].Value = model.TeacherEvaluation;
			parameters[5].Value = model.SelfEvaluation;
			parameters[6].Value = model.TeacherId;
			parameters[7].Value = model.SchoolTerm;
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
			strSql.Append("delete from Evaluation ");
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
			strSql.Append("delete from Evaluation ");
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
		public Eva.Model.Evaluation GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,StudentId,AcademicYear,Gpa,Ave,TeacherEvaluation,SelfEvaluation,TeacherId,SchoolTerm from Evaluation ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Eva.Model.Evaluation model=new Eva.Model.Evaluation();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"]!=null && ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["StudentId"]!=null && ds.Tables[0].Rows[0]["StudentId"].ToString()!="")
				{
					model.StudentId=int.Parse(ds.Tables[0].Rows[0]["StudentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["AcademicYear"]!=null && ds.Tables[0].Rows[0]["AcademicYear"].ToString()!="")
				{
					model.AcademicYear=int.Parse(ds.Tables[0].Rows[0]["AcademicYear"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Gpa"]!=null && ds.Tables[0].Rows[0]["Gpa"].ToString()!="")
				{
					model.Gpa=decimal.Parse(ds.Tables[0].Rows[0]["Gpa"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Ave"]!=null && ds.Tables[0].Rows[0]["Ave"].ToString()!="")
				{
					model.Ave=decimal.Parse(ds.Tables[0].Rows[0]["Ave"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TeacherEvaluation"]!=null && ds.Tables[0].Rows[0]["TeacherEvaluation"].ToString()!="")
				{
					model.TeacherEvaluation=ds.Tables[0].Rows[0]["TeacherEvaluation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["SelfEvaluation"]!=null && ds.Tables[0].Rows[0]["SelfEvaluation"].ToString()!="")
				{
					model.SelfEvaluation=ds.Tables[0].Rows[0]["SelfEvaluation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["TeacherId"]!=null && ds.Tables[0].Rows[0]["TeacherId"].ToString()!="")
				{
					model.TeacherId=int.Parse(ds.Tables[0].Rows[0]["TeacherId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SchoolTerm"]!=null && ds.Tables[0].Rows[0]["SchoolTerm"].ToString()!="")
				{
					model.SchoolTerm=int.Parse(ds.Tables[0].Rows[0]["SchoolTerm"].ToString());
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
			strSql.Append("select Id,StudentId,AcademicYear,Gpa,Ave,TeacherEvaluation,SelfEvaluation,TeacherId,SchoolTerm ");
			strSql.Append(" FROM Evaluation ");
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
			strSql.Append(" Id,StudentId,AcademicYear,Gpa,Ave,TeacherEvaluation,SelfEvaluation,TeacherId,SchoolTerm ");
			strSql.Append(" FROM Evaluation ");
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
			strSql.Append("select count(1) FROM Evaluation ");
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
			strSql.Append(")AS Row, T.*  from Evaluation T ");
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
			parameters[0].Value = "Evaluation";
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

