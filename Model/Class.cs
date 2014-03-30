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
		private int _name;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 班级名称
		/// </summary>
		public int Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		#endregion Model

	}
}

