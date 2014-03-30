using System;
namespace Eva.Model
{
	/// <summary>
	/// Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course
	{
		public Course()
		{}
		#region Model
		private int _id;
		private string _name;
		private decimal? _gpa;
		private string _introdution;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 课程名称
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 绩点
		/// </summary>
		public decimal? Gpa
		{
			set{ _gpa=value;}
			get{return _gpa;}
		}
		/// <summary>
		/// 课程介绍
		/// </summary>
		public string Introdution
		{
			set{ _introdution=value;}
			get{return _introdution;}
		}
		#endregion Model

	}
}

