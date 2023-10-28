using System.Linq.Expressions;

namespace Tumsas.RealEstate.Core.DataAccess.Base
{
    public interface IEntityRepositoryBase<T> where T : class, IEntityBase, new()
    {
        List<T> GetList(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        T Get(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        bool Save();
    }
}