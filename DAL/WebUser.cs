/**  版本信息模板在安装目录下，可自行修改。
* WebUser.cs
*
* 功 能： N/A
* 类 名： WebUser
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/19 12:56:09   N/A    初版
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
	/// 数据访问类:WebUser
	/// </summary>
	public partial class WebUser
	{
		public WebUser()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(Eva.Model.WebUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into WebUser(");
			strSql.Append("LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone)");
			strSql.Append(" values (");
			strSql.Append("@LoginId,@PassWord,@AuthorityId,@Name,@StudentId,@Sex,@CollegeId,@ClassId,@MajorId,@IdCard,@Address,@Phone)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginId", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@CollegeId", SqlDbType.Int,4),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@IdCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,-1),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50)};
			parameters[0].Value = model.LoginId;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.AuthorityId;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.StudentId;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.CollegeId;
			parameters[7].Value = model.ClassId;
			parameters[8].Value = model.MajorId;
			parameters[9].Value = model.IdCard;
			parameters[10].Value = model.Address;
			parameters[11].Value = model.Phone;

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
		public bool Update(Eva.Model.WebUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update WebUser set ");
			strSql.Append("LoginId=@LoginId,");
			strSql.Append("PassWord=@PassWord,");
			strSql.Append("AuthorityId=@AuthorityId,");
			strSql.Append("Name=@Name,");
			strSql.Append("StudentId=@StudentId,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("CollegeId=@CollegeId,");
			strSql.Append("ClassId=@ClassId,");
			strSql.Append("MajorId=@MajorId,");
			strSql.Append("IdCard=@IdCard,");
			strSql.Append("Address=@Address,");
			strSql.Append("Phone=@Phone");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@LoginId", SqlDbType.NVarChar,50),
					new SqlParameter("@PassWord", SqlDbType.NVarChar,50),
					new SqlParameter("@AuthorityId", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.NVarChar,50),
					new SqlParameter("@StudentId", SqlDbType.Int,4),
					new SqlParameter("@Sex", SqlDbType.NVarChar,50),
					new SqlParameter("@CollegeId", SqlDbType.Int,4),
					new SqlParameter("@ClassId", SqlDbType.Int,4),
					new SqlParameter("@MajorId", SqlDbType.Int,4),
					new SqlParameter("@IdCard", SqlDbType.NVarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,-1),
					new SqlParameter("@Phone", SqlDbType.NVarChar,50),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.LoginId;
			parameters[1].Value = model.PassWord;
			parameters[2].Value = model.AuthorityId;
			parameters[3].Value = model.Name;
			parameters[4].Value = model.StudentId;
			parameters[5].Value = model.Sex;
			parameters[6].Value = model.CollegeId;
			parameters[7].Value = model.ClassId;
			parameters[8].Value = model.MajorId;
			parameters[9].Value = model.IdCard;
			parameters[10].Value = model.Address;
			parameters[11].Value = model.Phone;
			parameters[12].Value = model.Id;

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
			strSql.Append("delete from WebUser ");
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
			strSql.Append("delete from WebUser ");
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
		public Eva.Model.WebUser GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone from WebUser ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			Eva.Model.WebUser model=new Eva.Model.WebUser();
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
		public Eva.Model.WebUser DataRowToModel(DataRow row)
		{
			Eva.Model.WebUser model=new Eva.Model.WebUser();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["LoginId"]!=null)
				{
					model.LoginId=row["LoginId"].ToString();
				}
				if(row["PassWord"]!=null)
				{
					model.PassWord=row["PassWord"].ToString();
				}
				if(row["AuthorityId"]!=null && row["AuthorityId"].ToString()!="")
				{
					model.AuthorityId=int.Parse(row["AuthorityId"].ToString());
				}
				if(row["Name"]!=null)
				{
					model.Name=row["Name"].ToString();
				}
				if(row["StudentId"]!=null && row["StudentId"].ToString()!="")
				{
					model.StudentId=int.Parse(row["StudentId"].ToString());
				}
				if(row["Sex"]!=null)
				{
					model.Sex=row["Sex"].ToString();
				}
				if(row["CollegeId"]!=null && row["CollegeId"].ToString()!="")
				{
					model.CollegeId=int.Parse(row["CollegeId"].ToString());
				}
				if(row["ClassId"]!=null && row["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(row["ClassId"].ToString());
				}
				if(row["MajorId"]!=null && row["MajorId"].ToString()!="")
				{
					model.MajorId=int.Parse(row["MajorId"].ToString());
				}
				if(row["IdCard"]!=null)
				{
					model.IdCard=row["IdCard"].ToString();
				}
				if(row["Address"]!=null)
				{
					model.Address=row["Address"].ToString();
				}
				if(row["Phone"]!=null)
				{
					model.Phone=row["Phone"].ToString();
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
			strSql.Append("select Id,LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone ");
			strSql.Append(" FROM WebUser ");
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
			strSql.Append(" Id,LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone ");
			strSql.Append(" FROM WebUser ");
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
			strSql.Append("select count(1) FROM WebUser ");
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
			strSql.Append(")AS Row, T.*  from WebUser T ");
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
			parameters[0].Value = "WebUser";
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

