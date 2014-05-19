/**  版本信息模板在安装目录下，可自行修改。
* ItemList.cs
*
* 功 能： N/A
* 类 名： ItemList
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/5/19 12:56:07   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
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

