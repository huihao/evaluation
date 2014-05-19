/**  版本信息模板在安装目录下，可自行修改。
* Teach.cs
*
* 功 能： N/A
* 类 名： Teach
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
namespace Eva.Model
{
	/// <summary>
	/// Teach:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Teach
	{
		public Teach()
		{}
		#region Model
		private int _id;
		private int? _courseid;
		private int? _teacherid;
		private int? _academicyear;
		private int? _schoolterm;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? AcademicYear
		{
			set{ _academicyear=value;}
			get{return _academicyear;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? SchoolTerm
		{
			set{ _schoolterm=value;}
			get{return _schoolterm;}
		}
		#endregion Model

	}
}

