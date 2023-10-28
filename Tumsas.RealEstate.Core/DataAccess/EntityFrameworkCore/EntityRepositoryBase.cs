using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tumsas.RealEstate.Core.DataAccess.Base;

namespace Tumsas.RealEstate.Core.DataAccess.EntityFrameworkCore
{
    public class EntityRepositoryBase<TEntity, TContext> : IDisposable, IEntityRepositoryBase<TEntity>
        where TEntity : class, IEntityBase, new()
        where TContext : DbContext, new()
    {
        private bool _disposed;
        protected TContext Context;

        public EntityRepositoryBase(TContext dataContext)
        {
            Context = dataContext;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> finalQuery;

            if (!includes.Any())
            {
                finalQuery = Context.Set<TEntity>();
            }
            else
            {
                var query = Context.Set<TEntity>().Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, expression) => current.Include(expression));
                finalQuery = query;
            }

            return filter == null
                ? finalQuery.ToList()
                : finalQuery.Where(filter).ToList();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query;

            if (!includes.Any())
            {
                query = Context.Set<TEntity>();
            }
            else
            {
                query = Context.Set<TEntity>().Include(includes.First());
                query = includes.Skip(1).Aggregate(query, (current, expression) => current.Include(expression));
            }

            return query.SingleOrDefault(filter);
        }

        public void Add(TEntity entity)
        {
            var addedEntity = Context.Entry(entity);
            addedEntity.State = EntityState.Added;
        }

        public void Update(TEntity entity)
        {
            var updatedEntity = Context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            var deletedEntity = Context.Entry(entity);

            deletedEntity.State = EntityState.Deleted;
        }

        public bool Save()
        {
            return Context.SaveChanges() > 0;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Context.Dispose();
            _disposed = true;
        }
    }
}
