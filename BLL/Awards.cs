using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
	/// <summary>
	/// Awards
	/// </summary>
	public partial class Awards
	{
		private readonly Eva.DAL.Awards dal=new Eva.DAL.Awards();
		public Awards()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Eva.Model.Awards model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Eva.Model.Awards model)
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
		public Eva.Model.Awards GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Eva.Model.Awards GetModelByCache(int Id)
		{
			
			string CacheKey = "AwardsModel-" + Id;
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
			return (Eva.Model.Awards)objModel;
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
		public List<Eva.Model.Awards> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Eva.Model.Awards> DataTableToList(DataTable dt)
		{
			List<Eva.Model.Awards> modelList = new List<Eva.Model.Awards>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Eva.Model.Awards model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Eva.Model.Awards();
					if(dt.Rows[n]["Id"]!=null && dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["Name"]!=null && dt.Rows[n]["Name"].ToString()!="")
					{
					model.Name=dt.Rows[n]["Name"].ToString();
					}
					if(dt.Rows[n]["Grade"]!=null && dt.Rows[n]["Grade"].ToString()!="")
					{
					model.Grade=dt.Rows[n]["Grade"].ToString();
					}
					if(dt.Rows[n]["Score"]!=null && dt.Rows[n]["Score"].ToString()!="")
					{
					model.Score=dt.Rows[n]["Score"].ToString();
					}
					if(dt.Rows[n]["StudentId"]!=null && dt.Rows[n]["StudentId"].ToString()!="")
					{
						model.StudentId=int.Parse(dt.Rows[n]["StudentId"].ToString());
					}
					if(dt.Rows[n]["AcademicYear"]!=null && dt.Rows[n]["AcademicYear"].ToString()!="")
					{
						model.AcademicYear=int.Parse(dt.Rows[n]["AcademicYear"].ToString());
					}
					if(dt.Rows[n]["SchoolTerm"]!=null && dt.Rows[n]["SchoolTerm"].ToString()!="")
					{
						model.SchoolTerm=int.Parse(dt.Rows[n]["SchoolTerm"].ToString());
					}
					if(dt.Rows[n]["IsCheck"]!=null && dt.Rows[n]["IsCheck"].ToString()!="")
					{
					model.IsCheck=dt.Rows[n]["IsCheck"].ToString();
					}
					if(dt.Rows[n]["Total"]!=null && dt.Rows[n]["Total"].ToString()!="")
					{
						model.Total=int.Parse(dt.Rows[n]["Total"].ToString());
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

