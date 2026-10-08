using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Entities.Concrete;

namespace EmployeeTaskManagement.Core.Utilities.Security.Jwt
{
	public interface ITokenHelper
	{
		AccessToken CreateToken(User user);
	}
}