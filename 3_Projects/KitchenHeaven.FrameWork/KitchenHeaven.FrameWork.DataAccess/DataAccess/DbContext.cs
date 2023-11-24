using System.Data;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// 
    /// </summary>
    public class DbContext : IDbContext
    {
        #region private properties
        private readonly IDbConnection _dbConnection;

        private readonly IDbTransaction _dbTransaction;
        #endregion

        public IDbConnection DbConnection { get{ return _dbConnection; } }

        public IDbTransaction DbTransaction { get { return _dbTransaction; } }

        public DbContext(IDbConnection dbConnection, IDbTransaction dbTransaction)
        { 
            _dbConnection = dbConnection;
            _dbTransaction = dbTransaction;
        }


    }
}
