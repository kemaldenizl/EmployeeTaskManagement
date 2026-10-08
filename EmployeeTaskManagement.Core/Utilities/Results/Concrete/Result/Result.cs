using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Utilities.Results.Abstract;

namespace EmployeeTaskManagement.Core.Utilities.Results.Concrete.Result
{
	public class Result:IResult
	{
		public Result(bool success, string message):this(success)
		{
			Message = message;
		}

		public Result(bool success)
		{
			Success = success;
		}
		public bool Success { get; }
		public string Message { get; }
	}
}