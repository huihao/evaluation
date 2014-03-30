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
		/// 课程ID
		/// </summary>
		public int? CourseId
		{
			set{ _courseid=value;}
			get{return _courseid;}
		}
		/// <summary>
		/// 教师ID
		/// </summary>
		public int? TeacherId
		{
			set{ _teacherid=value;}
			get{return _teacherid;}
		}
		/// <summary>
		/// 学年
		/// </summary>
		public int? AcademicYear
		{
			set{ _academicyear=value;}
			get{return _academicyear;}
		}
		/// <summary>
		/// 学期
		/// </summary>
		public int? SchoolTerm
		{
			set{ _schoolterm=value;}
			get{return _schoolterm;}
		}
		#endregion Model

	}
}

