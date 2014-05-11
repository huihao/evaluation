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
        public Eva.Model.WebUser Login(string sql)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone from WebUser ");
            strSql.Append(" where " +sql);           
            

            Eva.Model.WebUser model = new Eva.Model.WebUser();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoginId"] != null && ds.Tables[0].Rows[0]["LoginId"].ToString() != "")
                {
                    model.LoginId = ds.Tables[0].Rows[0]["LoginId"].ToString();
                }
                if (ds.Tables[0].Rows[0]["PassWord"] != null && ds.Tables[0].Rows[0]["PassWord"].ToString() != "")
                {
                    model.PassWord = ds.Tables[0].Rows[0]["PassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["AuthorityId"] != null && ds.Tables[0].Rows[0]["AuthorityId"].ToString() != "")
                {
                    model.AuthorityId = int.Parse(ds.Tables[0].Rows[0]["AuthorityId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["StudentId"] != null && ds.Tables[0].Rows[0]["StudentId"].ToString() != "")
                {
                    model.StudentId = int.Parse(ds.Tables[0].Rows[0]["StudentId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["CollegeId"] != null && ds.Tables[0].Rows[0]["CollegeId"].ToString() != "")
                {
                    model.CollegeId = int.Parse(ds.Tables[0].Rows[0]["CollegeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ClassId"] != null && ds.Tables[0].Rows[0]["ClassId"].ToString() != "")
                {
                    model.ClassId = int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["MajorId"] != null && ds.Tables[0].Rows[0]["MajorId"].ToString() != "")
                {
                    model.MajorId = int.Parse(ds.Tables[0].Rows[0]["MajorId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IdCard"] != null && ds.Tables[0].Rows[0]["IdCard"].ToString() != "")
                {
                    model.IdCard = ds.Tables[0].Rows[0]["IdCard"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Address"] != null && ds.Tables[0].Rows[0]["Address"].ToString() != "")
                {
                    model.Address = ds.Tables[0].Rows[0]["Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
       
            public Eva.Model.WebUser GetModel(string sql)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,LoginId,PassWord,AuthorityId,Name,StudentId,Sex,CollegeId,ClassId,MajorId,IdCard,Address,Phone from WebUser ");
			strSql.Append(" where "+sql);
			

			Eva.Model.WebUser model=new Eva.Model.WebUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["Id"]!=null && ds.Tables[0].Rows[0]["Id"].ToString()!="")
				{
					model.Id=int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
				}
				if(ds.Tables[0].Rows[0]["LoginId"]!=null && ds.Tables[0].Rows[0]["LoginId"].ToString()!="")
				{
					model.LoginId=ds.Tables[0].Rows[0]["LoginId"].ToString();
				}
				if(ds.Tables[0].Rows[0]["PassWord"]!=null && ds.Tables[0].Rows[0]["PassWord"].ToString()!="")
				{
					model.PassWord=ds.Tables[0].Rows[0]["PassWord"].ToString();
				}
				if(ds.Tables[0].Rows[0]["AuthorityId"]!=null && ds.Tables[0].Rows[0]["AuthorityId"].ToString()!="")
				{
					model.AuthorityId=int.Parse(ds.Tables[0].Rows[0]["AuthorityId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["StudentId"]!=null && ds.Tables[0].Rows[0]["StudentId"].ToString()!="")
				{
					model.StudentId=int.Parse(ds.Tables[0].Rows[0]["StudentId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Sex"]!=null && ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["CollegeId"]!=null && ds.Tables[0].Rows[0]["CollegeId"].ToString()!="")
				{
					model.CollegeId=int.Parse(ds.Tables[0].Rows[0]["CollegeId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ClassId"]!=null && ds.Tables[0].Rows[0]["ClassId"].ToString()!="")
				{
					model.ClassId=int.Parse(ds.Tables[0].Rows[0]["ClassId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MajorId"]!=null && ds.Tables[0].Rows[0]["MajorId"].ToString()!="")
				{
					model.MajorId=int.Parse(ds.Tables[0].Rows[0]["MajorId"].ToString());
				}
				if(ds.Tables[0].Rows[0]["IdCard"]!=null && ds.Tables[0].Rows[0]["IdCard"].ToString()!="")
				{
					model.IdCard=ds.Tables[0].Rows[0]["IdCard"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Address"]!=null && ds.Tables[0].Rows[0]["Address"].ToString()!="")
				{
					model.Address=ds.Tables[0].Rows[0]["Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
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

