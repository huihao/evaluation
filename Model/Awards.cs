using System;
namespace Eva.Model
{
	/// <summary>
	/// Awards:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Awards
	{
		public Awards()
		{}
		#region Model
		private int _id;
		private string _name;
		private string _grade;
		private string _score;
		private int? _studentid;
		private int? _academicyear;
		private int? _schoolterm;
		private string _ischeck;
		private int? _total;
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
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Grade
		{
			set{ _grade=value;}
			get{return _grade;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Score
		{
			set{ _score=value;}
			get{return _score;}
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
		public int? SchoolTerm
		{
			set{ _schoolterm=value;}
			get{return _schoolterm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IsCheck
		{
			set{ _ischeck=value;}
			get{return _ischeck;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? Total
		{
			set{ _total=value;}
			get{return _total;}
		}
		#endregion Model

	}
}

