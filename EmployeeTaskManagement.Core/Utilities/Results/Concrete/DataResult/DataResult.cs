using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;
using EmployeeTaskManagement.Core.Utilities.Results.Concrete.Result;

namespace EmployeeTaskManagement.Core.Utilities.Results.Concrete.DataResult
{
	public class DataResult<T> : Result.Result, IDataResult<T>
	{
		public DataResult(T data, bool success, string message) : base(success, message)
		{
			Data = data;
		}

		public DataResult(T data, bool success):base(success)
		{
			Data = data;
		}

		public T Data { get; }
	}
}