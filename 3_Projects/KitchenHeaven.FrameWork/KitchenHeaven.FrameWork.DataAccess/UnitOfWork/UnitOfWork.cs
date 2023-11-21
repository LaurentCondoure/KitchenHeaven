using Microsoft.Data.Sqlite;
using System;
using System.Data;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;

namespace KitchenHeaven.FrameWork.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region private properties
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        private bool _disposed;

        private readonly IIngredientDataAccess _ingredientDataAccess;
        private readonly IMealDataAccess _mealDataAccess;
        private readonly IMealIngredientDataAccess _mealIngredientDataAccess;
        private readonly IMenuDataAccess _menuDataAccess;
        private readonly IRestaurantDataAccess _restaurantDataAccess;
        #endregion

        public UnitOfWork(IIngredientDataAccess ingredientDataAccess
                            , IMealDataAccess mealDataAccess
                            , IMealIngredientDataAccess mealIngredientDataAccess
                            , IMenuDataAccess menuDataAccess
                            , IRestaurantDataAccess restaurantDataAccess)
        {
            _ingredientDataAccess = ingredientDataAccess;
            _mealDataAccess = mealDataAccess;
            _mealIngredientDataAccess = mealIngredientDataAccess;
            _menuDataAccess = menuDataAccess;
            _restaurantDataAccess = restaurantDataAccess;
        }

        #region IUnitOfWork interface
        public IIngredientDataAccess IngredientDataAccess { get; }

        public IMealDataAccess MealDataAccess { get; }

        public IMealIngredientDataAccess MealIngredientDataAccess { get; }

        public IMenuDataAccess MenuDataAccess { get; }

        public IRestaurantDataAccess RestaurantDataAccess { get; }

        

        public void Begin(string connectionString, bool useTransaction)
        {
            if(string.IsNullOrWhiteSpace(connectionString))
                throw new ArgumentNullException("connectionString cannot be null");
            _connection = new SqliteConnection(connectionString);
            _connection.Open();
            if (useTransaction)
                _transaction = _connection.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction?.Commit();
            }
            catch
            {
                Finalize();
            }
        }

        public void Rollback()
        {
            try
            {
                _transaction?.Rollback();
            }
            catch
            {
                Finalize();
            }
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

        private void Finalize()
        {
            _transaction?.Dispose();
            _transaction = null;
            _connection?.Close();
            _connection?.Dispose();
            _connection = null;
        }
        #endregion


    }
}
