using Microsoft.Data.Sqlite;
using System;
using System.Data;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.DataAccess;

namespace KitchenHeaven.FrameWork.DataAccess.UOW
{
    /// <summary>
    /// Class exposing methods to manage database connection and transaction shared accross DataAccess
    /// Then, request can be executed in the same context, and insert in differents tables can be rollback more easyly 
    /// TODO : make connection and transaction instanciate separatly : OpenConnection/CloseConnection 
    /// /!\ 
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region private properties
        private IDbConnection _connection;
        private IDbTransaction _transaction;

        //DbContext created at the Begin method
        //Shared to all data context when 
        private IDbContext _dbContext;

        private bool _disposed = false;

        private IIngredientDataAccess _ingredientDataAccess;
        private IMealDataAccess _mealDataAccess;
        private IMealIngredientDataAccess _mealIngredientDataAccess;
        private IMenuDataAccess _menuDataAccess;
        private IRestaurantDataAccess _restaurantDataAccess;
        #endregion


        #region IUnitOfWork interface
        /// <summary>
        /// Start a new context.
        /// </summary>
        /// <param name="connectionString">Connection string to the database</param>
        /// <param name="useTransaction">active transaction or not</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Begin(string connectionString, bool useTransaction)
        {
            if (_connection != null)
                throw new Exception("a connection have been initiated and not yet terminated");

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

        /// <summary>
        /// Perfome action in database
        /// </summary>
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

        /// <summary>
        /// Rollback all changes
        /// </summary>
        public void Rollback()
        {
            _transaction?.Rollback();
            FinalizeConnection();
        }

        /// <summary>
        /// return the current IngredientDataAccess.
        /// Create a new one and share the connection if null.
        /// </summary>
        /// <returns>Object implementing IIngredientDataAccess</returns>
        /// <exception cref="Exception"></exception>
        public IIngredientDataAccess GetIngredientDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            if(_ingredientDataAccess == null)
                _ingredientDataAccess = new IngredientDataAccess(_dbContext);
            return _ingredientDataAccess;
        }

        /// <summary>
        /// return the current MenuDataAccess.
        /// Create a new one and share the connection if null.
        /// </summary>
        /// <returns>Object implementing IMealDataAccess</returns>
        /// <exception cref="Exception"></exception>

        public IMealDataAccess GetMealDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            if(_mealDataAccess == null)
                _mealDataAccess = new MealDataAccess(_dbContext);
            return _mealDataAccess;
        }

        /// <summary>
        /// return the current MealIngredientDataAccess.
        /// Create a new one and share the connection if null.
        /// </summary>
        /// <returns>Object implementing IMealIngredientDataAccess</returns>
        /// <exception cref="Exception"></exception>

        public IMealIngredientDataAccess GetMealIngredientDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            if(_mealIngredientDataAccess == null)
                _mealIngredientDataAccess = new MealIngredientDataAccess(_dbContext);
            return _mealIngredientDataAccess;
        }

        /// <summary>
        /// return the current IMenuDataAccess.
        /// Create a new one and share the connection if null.
        /// </summary>
        /// <returns>Object implementing IMenuDataAccess</returns>
        /// <exception cref="Exception"></exception>

        public IMenuDataAccess GetMenuDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            if(_menuDataAccess == null)
                _menuDataAccess = new MenuDataAccess(_dbContext);
            return _menuDataAccess;
        }

        /// <summary>
        /// return the current IRestaurantDataAccess.
        /// Create a new one and share the connection if null.
        /// </summary>
        /// <returns>Object implementing IRestaurantDataAccess</returns>
        /// <exception cref="Exception"></exception>
        public IRestaurantDataAccess GetRestaurantDataAccess()
        {
            if (_dbContext == null || _dbContext.DbConnection == null)
                throw new Exception("DataBaseContext must be initialize by Begin method");
            if(_restaurantDataAccess == null)
                _restaurantDataAccess = new RestaurantDataAccess(_dbContext);
            return _restaurantDataAccess;
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
            FinalizeDataAccess();

            
            _transaction?.Dispose();
            _transaction = null;
            if (_connection?.State != ConnectionState.Closed)
                _connection?.Close();
            if (_connection != null)
                SqliteConnection.ClearPool((SqliteConnection)_connection);
            _connection?.Dispose();
            _connection = null;

            
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
