using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
	/// <summary>
	/// Teach
	/// </summary>
	public partial class Teach
	{
		private readonly Eva.DAL.Teach dal=new Eva.DAL.Teach();
		public Teach()
		{}
		#region  Method

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Eva.Model.Teach model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Eva.Model.Teach model)
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
		public Eva.Model.Teach GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Eva.Model.Teach GetModelByCache(int Id)
		{
			
			string CacheKey = "TeachModel-" + Id;
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
			return (Eva.Model.Teach)objModel;
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
		public List<Eva.Model.Teach> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Eva.Model.Teach> DataTableToList(DataTable dt)
		{
			List<Eva.Model.Teach> modelList = new List<Eva.Model.Teach>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Eva.Model.Teach model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Eva.Model.Teach();
					if(dt.Rows[n]["Id"]!=null && dt.Rows[n]["Id"].ToString()!="")
					{
						model.Id=int.Parse(dt.Rows[n]["Id"].ToString());
					}
					if(dt.Rows[n]["CourseId"]!=null && dt.Rows[n]["CourseId"].ToString()!="")
					{
						model.CourseId=int.Parse(dt.Rows[n]["CourseId"].ToString());
					}
					if(dt.Rows[n]["TeacherId"]!=null && dt.Rows[n]["TeacherId"].ToString()!="")
					{
						model.TeacherId=int.Parse(dt.Rows[n]["TeacherId"].ToString());
					}
					if(dt.Rows[n]["AcademicYear"]!=null && dt.Rows[n]["AcademicYear"].ToString()!="")
					{
						model.AcademicYear=int.Parse(dt.Rows[n]["AcademicYear"].ToString());
					}
					if(dt.Rows[n]["SchoolTerm"]!=null && dt.Rows[n]["SchoolTerm"].ToString()!="")
					{
						model.SchoolTerm=int.Parse(dt.Rows[n]["SchoolTerm"].ToString());
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

