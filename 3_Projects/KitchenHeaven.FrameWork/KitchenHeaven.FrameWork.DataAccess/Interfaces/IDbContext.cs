using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IDbContext
    {
        IDbConnection DbConnection { get; }
        IDbTransaction DbTransaction { get; }
    }
}
