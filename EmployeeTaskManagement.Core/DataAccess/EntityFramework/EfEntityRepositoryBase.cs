using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EmployeeTaskManagement.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeTaskManagement.Core.DataAccess.EntityFramework
{
	public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
	where TEntity : class, IEntity, new()
	where TContext : DbContext, new()
	{
        public async Task<IList<TEntity>> GetAll(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? filter = null)
		{
			using (var context = new TContext())
			{
				return filter == null ? 
					await context.Set<TEntity>().ToListAsync(cancellationToken) :
					await context.Set<TEntity>().Where(filter).ToListAsync(cancellationToken);
			}
		}
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken)
		{
			using (var context = new TContext())
			{
				return await context.Set<TEntity>().SingleOrDefaultAsync(filter, cancellationToken);
			}
		}
		public async Task Add(TEntity entity, CancellationToken cancellationToken)
		{
			using (var context = new TContext())
			{
				var addedEntity = context.Entry(entity);
				addedEntity.State = EntityState.Added;
				await context.SaveChangesAsync(cancellationToken);
			}
		}
        public async Task Update(TEntity entity, CancellationToken cancellationToken)
		{
			using (var context = new TContext())
			{
				var updatedEntity = context.Entry(entity);
				updatedEntity.State = EntityState.Modified;
				await context.SaveChangesAsync(cancellationToken);
			}
		}
		public async Task Delete(TEntity entity, CancellationToken cancellationToken)
		{
			using (var context = new TContext())
			{
				var deletedEntity = context.Entry(entity);
				deletedEntity.State = EntityState.Deleted;
				await context.SaveChangesAsync(cancellationToken);
			}
		}
	}
}