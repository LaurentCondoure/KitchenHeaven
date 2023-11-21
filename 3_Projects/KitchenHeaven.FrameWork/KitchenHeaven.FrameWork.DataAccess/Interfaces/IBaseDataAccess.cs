using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IBaseDataAccess<T>
    {
        void SetDbContext(IDbConnection dbConnection);
        T GetById(int Id);

        T GetByExternalId(string Id);

        int Add(T entity);

    }
}
