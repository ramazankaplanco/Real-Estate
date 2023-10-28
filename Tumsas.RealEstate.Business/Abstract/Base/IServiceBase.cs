using Tumsas.RealEstate.DataAccess.Concrete.Dto.Base;

namespace Tumsas.RealEstate.Business.Abstract.Base
{
    public interface IServiceBase<T> where T : class, new()
    {
        ResponseBase<List<T>> GetList();

        ResponseBase<T> GetById(int id);

        ResponseBase<T> Add(T item);

        ResponseBase<bool> UpdateById(int id, T item);

        ResponseBase<bool> DeleteById(int id);
    }
}