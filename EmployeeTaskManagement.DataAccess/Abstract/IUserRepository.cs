using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.DataAccess;
using EmployeeTaskManagement.Core.Entities.Concrete;

namespace EmployeeTaskManagement.DataAccess.Abstract
{
	public interface IUserRepository:IEntityRepository<User>
	{
	}
}