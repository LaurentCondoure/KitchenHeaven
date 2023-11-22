using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        T GetById(int Id);

        T GetByExternalId(string Id);

        int Add(T entity);

    }
}
