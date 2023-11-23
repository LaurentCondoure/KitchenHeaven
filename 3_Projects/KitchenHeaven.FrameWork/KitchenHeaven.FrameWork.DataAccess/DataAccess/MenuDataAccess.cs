﻿using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MenuDataAccess : IMenuDataAccess
    {
        #region private properties
        private IDbContext _dbContext;
        #endregion

        public MenuDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region CREATE
        public int Add(Menu entity)
        {
            return _dbContext.DbConnection.ExecuteScalar<int>(MenuQueries.Add
                                                              , new
                                                                  {
                                                                      meal = entity.MealId,
                                                                      restaurantId = entity.ResturantId
                                                                  }
                                                              , _dbContext.DbTransaction);
        }
        #endregion

        #region READ
        public int CheckMealInMenu(string mealExternalId)
        {
            return _dbContext.DbConnection.ExecuteScalar<int>(MenuQueries.GetMealByExternalId
                                                                , new { externalId = mealExternalId }
                                                                , _dbContext.DbTransaction);
        }
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

    }
}