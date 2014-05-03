using System;
namespace Eva.Model
{
	/// <summary>
	/// Major:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Major
	{
		public Major()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _collegeid;
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
		public int? CollegeId
		{
			set{ _collegeid=value;}
			get{return _collegeid;}
		}
		#endregion Model

	}
}

