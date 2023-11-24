using System;
using System.Collections.Generic;
using System.Data;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;
using Microsoft.Data.Sqlite;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Classe instaciating methods to exhange data with DataBase focus on Meal Entity
    /// </summary>
    public class MealDataAccess : IMealDataAccess
    {
        private readonly IDbContext _dbContext;

        public MealDataAccess(IDbContext dbContext)
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

        public int Add(Meal entity)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<int>(MealQueries.Add
                                                              , new
                                                                  {
                                                                      name = entity.Name,
                                                                      externalId = entity.ExternalId,
                                                                      area = entity.Area,
                                                                      cateagory = entity.Category,
                                                                      image = entity.Image,
                                                                      instructions = entity.Instructions,
                                                                      miniature = entity.Miniature
                                                                  }
                                                              , _dbContext.DbTransaction);
        }

        public Meal GetByExternalIdAndRestaurantId(string externalId, int restaurantId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            try
            {
                return _dbContext.DbConnection.QueryFirst<Meal>(MealQueries.GetByExternalIdAndRestaurantId
                                                                    , new
                                                                    {
                                                                        externalId = externalId,
                                                                        restaurantId = restaurantId
                                                                    }
                                                                    , _dbContext.DbTransaction);
            }
            catch (Exception ex)
            {
                string test = "test";
                throw;
            }
        }

        public Meal GetById(int id)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.QueryFirst<Meal>(MealQueries.GetById, new { id = id });
        }

        public IEnumerable<Meal> GetByRestaurantId(int restaurantId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.Query<Meal>(MealQueries.GetByRestaurantId
                                                        , new { restaurantId = restaurantId }
                                                        , _dbContext.DbTransaction);
        }

        
        #region Not Implemented
        public IEnumerable<Meal> GetAll()
        {
            throw new NotImplementedException();
        }
        public Meal GetByExternalId(string externalId)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
