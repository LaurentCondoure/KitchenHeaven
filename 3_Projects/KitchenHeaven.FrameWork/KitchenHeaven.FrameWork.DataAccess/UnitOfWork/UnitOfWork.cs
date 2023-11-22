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

        private readonly IDbContext _dbContext;

        private bool _disposed = false;

        private IIngredientDataAccess _ingredientDataAccess;
        private IMealDataAccess _mealDataAccess;
        private IMealIngredientDataAccess _mealIngredientDataAccess;
        private IMenuDataAccess _menuDataAccess;
        private IRestaurantDataAccess _restaurantDataAccess;
        #endregion

        public UnitOfWork(string connectionString, bool useTransaction)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString cannot be null");
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            if (useTransaction)
                _transaction = _connection.BeginTransaction();

            _dbContext = new DbContext(_connection, _transaction);
        }

        #region IUnitOfWork interface
        public IIngredientDataAccess IngredientDataAccess 
        { 
          get 
              { return _ingredientDataAccess 
                          ?? (_ingredientDataAccess 
                                  = new IngredientDataAccess(_dbContext)); 
              } 
        }

        public IMealDataAccess MealDataAccess
        {
            get
            {
                return _mealDataAccess
                          ?? (_mealDataAccess
                                  = new MealDataAccess(_dbContext));
            }
        }

        public IMealIngredientDataAccess MealIngredientDataAccess
        {
            get
            {
                return _mealIngredientDataAccess
                          ?? (_mealIngredientDataAccess
                                  = new MealIngredientDataAccess(_dbContext));
            }
        }

        public IMenuDataAccess MenuDataAccess
        {
            get
            {
                return _menuDataAccess
                          ?? (_menuDataAccess
                                  = new MenuDataAccess(_dbContext));
            }
        }

        public IRestaurantDataAccess RestaurantDataAccess
        {
            get
            {
                return _restaurantDataAccess
                          ?? (_restaurantDataAccess
                                  = new RestaurantDataAccess(_dbContext));
            }
        }

        //If connection is created in constrctor and transaction in Begin method,
        //there is a way to insert multiple table withourt expected result in use
        //public void Begin(bool useTransaction)
        //{

        //}

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                _transaction?.Rollback();
                throw;
            }
        }

        public void Rollback()
        {
            _transaction?.Rollback();
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
                    if (_transaction != null)
                    {
                        _transaction?.Dispose();
                        _transaction = null;
                    }
                    if (_connection != null)
                    {
                        if(_connection.State != ConnectionState.Closed)
                            _connection?.Close();
                        _connection?.Dispose();
                        _connection = null;
                    }
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

        ~UnitOfWork()
        {
            FinalizeDataAccess();


            _transaction?.Dispose();
            _transaction = null;
            if (_connection?.State != ConnectionState.Closed)
                _connection?.Close();
            _connection?.Dispose();
            _connection = null;
        }
        #endregion


    }
}
