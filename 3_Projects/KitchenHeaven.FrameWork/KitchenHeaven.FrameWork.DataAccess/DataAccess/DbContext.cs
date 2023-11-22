using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using System;
using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
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
