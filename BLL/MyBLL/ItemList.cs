using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using Eva.Model;
namespace Eva.BLL
{
	/// <summary>
	/// ItemList
	/// </summary>
	public partial class ItemList
	{
        public DataSet GetListByEvaId(int evaId)
        {
            return dal.GetList(" EvaluationId=" + evaId);
        }
		
	}
}

