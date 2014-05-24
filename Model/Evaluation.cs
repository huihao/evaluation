/**  版本信息模板在安装目录下，可自行修改。
* Evaluation.cs
*
* 功 能： N/A
* 类 名： Evaluation
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/19 21:12:08   N/A    初版
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
	/// Evaluation:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Evaluation
	{
		public Evaluation()
		{}
		#region Model
		private int _id;
		private int? _studentid;
		private int? _academicyear;
		private decimal? _gpa;
		private decimal? _ave;
		private string _teacherevaluation;
		private string _selfevaluation;
		private int? _teacherid;
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
		public int? StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
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
		public decimal? Gpa
		{
			set{ _gpa=value;}
			get{return _gpa;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? Ave
		{
			set{ _ave=value;}
			get{return _ave;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherEvaluation
		{
			set{ _teacherevaluation=value;}
			get{return _teacherevaluation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SelfEvaluation
		{
			set{ _selfevaluation=value;}
			get{return _selfevaluation;}
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
		public int? SchoolTerm
		{
			set{ _schoolterm=value;}
			get{return _schoolterm;}
		}
		#endregion Model

	}
}

