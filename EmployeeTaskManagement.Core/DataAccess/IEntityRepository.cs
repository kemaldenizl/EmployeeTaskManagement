using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Entities;

namespace EmployeeTaskManagement.Core.DataAccess
{
	public interface IEntityRepository<T> where T:class,IEntity,new()
	{
		Task<IList<T>> GetAll(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null);
		Task<T> Get(Expression<Func<T, bool>> filter, CancellationToken cancellationToken);
		Task Add(T entity, CancellationToken cancellationToken);
		Task Update(T entity, CancellationToken cancellationToken);
		Task Delete(T entity, CancellationToken cancellationToken);
	}
}