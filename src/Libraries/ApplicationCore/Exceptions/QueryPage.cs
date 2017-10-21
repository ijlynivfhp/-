using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using ApplicationCore.Entities;

namespace ApplicationCore
{
    public class QueryPageParameter
	{
		/// <summary>
		/// 当前页数（第几页）
		/// </summary>
		public int PageIndex { get; set; }
		/// <summary>
		/// 每页记录数
		/// </summary>
		public int PageSize { get; set; }

		/// <summary>
		/// 总记录数
		/// </summary>
		public int TotalNumber { get;private set; }

		/// <summary>
		/// 查询到的记录
		/// </summary>
		public IEnumerable<object> Result { get; private set; }

		public QueryPageParameter  SetResult(IEnumerable<object> result)
		{
			Result = result;
			return this;
		}
		public QueryPageParameter SetTotalNumber(int num) {
			TotalNumber = num;
			return this;
		}


	}
}
