using Microsoft.Data.Sqlite;
using System;
using System.Data;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.DataAccess;

namespace KitchenHeaven.FrameWork.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region private properties
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        private IDbContext _dbContext;

        private bool _disposed = false;

        private IIngredientDataAccess _ingredientDataAccess;
        private IMealDataAccess _mealDataAccess;
        private IMealIngredientDataAccess _mealIngredientDataAccess;
        private IMenuDataAccess _menuDataAccess;
        private IRestaurantDataAccess _restaurantDataAccess;
        #endregion


        #region IUnitOfWork interface

        public void Begin(string connectionString, bool useTransaction)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString cannot be null");
            if (_connection != null)
                throw new ArgumentNullException("connection alreadyOpen to the database");
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            if (useTransaction)
                _transaction = _connection.BeginTransaction();

            _dbContext = new DbContext(_connection, _transaction);
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
                FinalizeConnection();
            }
            catch
            {
                _transaction?.Rollback();
                FinalizeConnection();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
            FinalizeConnection();
        }

        public IIngredientDataAccess GetIngredientDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            return new IngredientDataAccess(_dbContext);
        }

        public IMealDataAccess GetMealDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            return new MealDataAccess(_dbContext);
        }

        public IMealIngredientDataAccess GetMealIngredientDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            return new MealIngredientDataAccess(_dbContext);
        }

        public IMenuDataAccess GetMenuDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            return new MenuDataAccess(_dbContext);
        }

        public IRestaurantDataAccess GetRestaurantDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            return new RestaurantDataAccess(_dbContext);
        }

        #endregion

        #region IDisposable interface
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region Private Methods
        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    FinalizeConnection();
                }
                _disposed = true;
            }
        }

        private void FinalizeDataAccess()
        {
            _ingredientDataAccess = null;
            _mealDataAccess = null;
            _menuDataAccess = null;
            _restaurantDataAccess = null;
            _mealIngredientDataAccess = null;
        }

        private void FinalizeConnection()
        {

            _transaction?.Dispose();
            _transaction = null;
            if (_connection?.State != ConnectionState.Closed)
                _connection?.Close();
            _connection?.Dispose();
            _connection = null;
            FinalizeDataAccess();
        }

        private void FinalizeTransaction()
        {
        }

        ~UnitOfWork()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                if (_transaction != null)
                {
                    _transaction.Rollback();
                }
            }

            FinalizeConnection();
            FinalizeDataAccess();
        }
        #endregion


    }
}
