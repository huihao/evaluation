using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
	/// <summary>
	/// Item
	/// </summary>
	public partial class Item
	{
        public List<Eva.Model.Item> GetModelAllList()
        {
            DataSet ds = dal.GetList("");
            return DataTableToList(ds.Tables[0]);
        }
	}
}

