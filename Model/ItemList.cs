using System;
namespace Eva.Model
{
	/// <summary>
	/// ItemList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ItemList
	{
		public ItemList()
		{}
		#region Model
		private int _id;
		private int? _evaluationid;
		private int? _itemid;
		private string _evaluation;
		private int? _score;
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
		public int? EvaluationId
		{
			set{ _evaluationid=value;}
			get{return _evaluationid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? ItemId
		{
			set{ _itemid=value;}
			get{return _itemid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Evaluation
		{
			set{ _evaluation=value;}
			get{return _evaluation;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? score
		{
			set{ _score=value;}
			get{return _score;}
		}
		#endregion Model

	}
}

