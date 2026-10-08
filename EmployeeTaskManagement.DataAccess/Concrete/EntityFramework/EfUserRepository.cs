using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.DataAccess.EntityFramework;
using EmployeeTaskManagement.Core.Entities.Concrete;
using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts;

namespace EmployeeTaskManagement.DataAccess.Concrete.EntityFramework
{
	public class EfUserRepository : EfEntityRepositoryBase<User, EmployeeTaskManagementContext>, IUserRepository
	{
	}
}