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
		/// 学生编号
		/// </summary>
		public int? StudentId
		{
			set{ _studentid=value;}
			get{return _studentid;}
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
		/// 平均绩点
		/// </summary>
		public decimal? Gpa
		{
			set{ _gpa=value;}
			get{return _gpa;}
		}
		/// <summary>
		/// 平均分
		/// </summary>
		public decimal? Ave
		{
			set{ _ave=value;}
			get{return _ave;}
		}
		/// <summary>
		/// 教师评价
		/// </summary>
		public string TeacherEvaluation
		{
			set{ _teacherevaluation=value;}
			get{return _teacherevaluation;}
		}
		/// <summary>
		/// 学生自评
		/// </summary>
		public string SelfEvaluation
		{
			set{ _selfevaluation=value;}
			get{return _selfevaluation;}
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

