using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        bool CheckDbContext();
        T GetById(int Id);

        T GetByExternalId(string Id);

        int Add(T entity);

        IEnumerable<T> GetAll();

    }
}
