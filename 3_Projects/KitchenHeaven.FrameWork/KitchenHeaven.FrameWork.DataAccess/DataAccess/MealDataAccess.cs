using System;
using System.Collections.Generic;
using System.Data;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
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
                throw new Exception("Database connection is not initialized");)
            return _dbContext.DbConnection.ExecuteScalar<int>(MealQueries.Add
                                                              , new
                                                                  {
                                                                      name = entity.Name,
                                                                      externalId = entity.ExternalId,
                                                                      area = entity.Area,
                                                                      cateagory = entity.Category,
                                                                      image = entity.Image,
                                                                      instructions = entity.Instructions
                                                                  }
                                                              , _dbContext.DbTransaction);
        }

        public Meal GetByExternalId(string externalId)
        {
            throw new NotImplementedException();
        }

        public Meal GetByExternalIdAndRestaurantId(string externalId, int restaurantId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<Meal>(MealQueries.GetByExternalIdAndRestaurantId
                                                                , new
                                                                {
                                                                    externalId = externalId,
                                                                    restaurantId = restaurantId
                                                                }
                                                                , _dbContext.DbTransaction);
        }

        public Meal GetById(int id)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<Meal>(MealQueries.GetById, new { id = id });
        }

        public IEnumerable<Meal> GetByRestaurantId(int restaurantId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.Query<Meal>(MealQueries.GetByRestaurantId
                                                        , new { restaurantId = restaurantId }
                                                        , _dbContext.DbTransaction);
        }

        public IEnumerable<Meal> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
