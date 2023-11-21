using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    internal class DbContext : IDbContext
    {
        #region private properties
        private IDbConnection _dbConnection;

        private IDbTransaction _dbTransaction;
        #endregion

        public IDbConnection DbConnection => throw new System.NotImplementedException();

        public IDbTransaction DbTransaction => throw new System.NotImplementedException();

        public DbContext(IDbConnection dbConnection, IDbTransaction dbTransaction)
        { 
            _dbConnection = dbConnection;
            _dbTransaction = dbTransaction;
        }
    }
}
