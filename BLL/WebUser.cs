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
		private readonly Eva.DAL.WebUser dal=new Eva.DAL.WebUser();
		public WebUser()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Eva.Model.WebUser model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Eva.Model.WebUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			return dal.DeleteList(Idlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Eva.Model.WebUser GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Eva.Model.WebUser GetModelByCache(int Id)
		{
			
			string CacheKey = "WebUserModel-" + Id;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Eva.Model.WebUser)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Eva.Model.WebUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Eva.Model.WebUser> DataTableToList(DataTable dt)
		{
			List<Eva.Model.WebUser> modelList = new List<Eva.Model.WebUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Eva.Model.WebUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Eva.Model.WebUser();
					if(dt.Rows[n]["Id"]!=null && dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["LoginId"]!=null && dt.Rows[n]["LoginId"].ToString()!="")
					{
					model.LoginId=dt.Rows[n]["LoginId"].ToString();
					}
					if(dt.Rows[n]["PassWord"]!=null && dt.Rows[n]["PassWord"].ToString()!="")
					{
					model.PassWord=dt.Rows[n]["PassWord"].ToString();
					}
					if(dt.Rows[n]["AuthorityId"]!=null && dt.Rows[n]["AuthorityId"].ToString()!="")
					{
						model.AuthorityId=int.Parse(dt.Rows[n]["AuthorityId"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["StudentId"]!=null && dt.Rows[n]["StudentId"].ToString()!="")
					{
						model.StudentId=int.Parse(dt.Rows[n]["StudentId"].ToString());
					}
					if(dt.Rows[n]["Sex"]!=null && dt.Rows[n]["Sex"].ToString()!="")
					{
					model.Sex=dt.Rows[n]["Sex"].ToString();
					}
					if(dt.Rows[n]["CollegeId"]!=null && dt.Rows[n]["CollegeId"].ToString()!="")
					{
						model.CollegeId=int.Parse(dt.Rows[n]["CollegeId"].ToString());
					}
					if(dt.Rows[n]["ClassId"]!=null && dt.Rows[n]["ClassId"].ToString()!="")
					{
						model.ClassId=int.Parse(dt.Rows[n]["ClassId"].ToString());
					}
					if(dt.Rows[n]["MajorId"]!=null && dt.Rows[n]["MajorId"].ToString()!="")
					{
						model.MajorId=int.Parse(dt.Rows[n]["MajorId"].ToString());
					}
					if(dt.Rows[n]["IdCard"]!=null && dt.Rows[n]["IdCard"].ToString()!="")
					{
					model.IdCard=dt.Rows[n]["IdCard"].ToString();
					}
					if(dt.Rows[n]["Address"]!=null && dt.Rows[n]["Address"].ToString()!="")
					{
					model.Address=dt.Rows[n]["Address"].ToString();
					}
					if(dt.Rows[n]["Phone"]!=null && dt.Rows[n]["Phone"].ToString()!="")
					{
					model.Phone=dt.Rows[n]["Phone"].ToString();
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  Method
	}
}

