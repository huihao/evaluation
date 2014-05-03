using System;
namespace Eva.Model
{
	/// <summary>
	/// Class:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Class
	{
		public Class()
		{}
		#region Model
		private int _id;
		private string _name;
		private int? _majorid;
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
		public int? MajorId
		{
			set{ _majorid=value;}
			get{return _majorid;}
		}
		#endregion Model

	}
}

