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

