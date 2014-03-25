﻿using System;
namespace Eva.Model
{
	/// <summary>
	/// Mark:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Mark
	{
		public Mark()
		{}
		#region Model
		private int _id;
		private int? _courseid;
		private int? _studentid;
		private int? _evalutionid;
		private decimal _score;
		private decimal? _bonuspoint;
		private int? _academicyear;
		private int? _schoolterm;
		private int? _checkstep;
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
		public int? StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? EvalutionId
		{
			set{ _evalutionid=value;}
			get{return _evalutionid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal Score
		{
			set{ _score=value;}
			get{return _score;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? BonusPoint
		{
			set{ _bonuspoint=value;}
			get{return _bonuspoint;}
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
		/// <summary>
		/// 
		/// </summary>
		public int? CheckStep
		{
			set{ _checkstep=value;}
			get{return _checkstep;}
		}
		#endregion Model

	}
}

