using System;
using System.Collections.Generic;
using System.Data;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Classe instaciating methods to exchange data with DataBase focus on Menu Entity
    /// </summary>
    public class MenuDataAccess : IMenuDataAccess
    {
        #region private properties
        private IDbContext _dbContext;
        #endregion

        public MenuDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckDbContext()
        {
            if (_dbContext == null || (_dbContext.DbConnection == null || _dbContext.DbConnection.State != ConnectionState.Open))
                return false;
            else
                return true;
        }

        #region CREATE
        public int Add(Menu entity)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<int>(MenuQueries.Add
                                                              , new
                                                                  {
                                                                      meal = entity.MealId,
                                                                      restaurantId = entity.RestaurantId
                                                                  }
                                                              , _dbContext.DbTransaction);
        }
        #endregion

        #region READ
        public int CheckMealInMenu(string mealExternalId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<int>(MenuQueries.GetMealByExternalId
                                                                , new { externalId = mealExternalId }
                                                                , _dbContext.DbTransaction);
        }


        #region not implemented
        public IEnumerable<Menu> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Menu GetByExternalId(string Id)
        {
            throw new System.NotImplementedException();
        }

        public Menu GetById(int Id)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #endregion

    }
}
