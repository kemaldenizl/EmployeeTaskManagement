using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.DataAccess.EntityFramework;
using EmployeeTaskManagement.DataAccess.Abstract;
using EmployeeTaskManagement.DataAccess.Concrete.EntityFramework.Contexts;
using EmployeeTaskManagement.Entities.Concrete;

namespace EmployeeTaskManagement.DataAccess.Concrete.EntityFramework
{
	public class EfEmployeeRepository : EfEntityRepositoryBase<Employee, EmployeeTaskManagementContext>, IEmployeeRepository
	{
	}
}