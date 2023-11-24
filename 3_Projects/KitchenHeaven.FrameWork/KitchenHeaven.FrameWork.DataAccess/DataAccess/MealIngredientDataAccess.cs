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
    /// Classe instaciating methods to exchange data with DataBase focus on MealIngredient Entity
    /// </summary>
    //public class MealIngredientDataAccess : BaseDataAccess, IMealIngredientDataAccess
    public class MealIngredientDataAccess : IMealIngredientDataAccess
    {
        #region private properties
        private IDbContext _dbContext;
        #endregion

        public MealIngredientDataAccess(IDbContext dbContext)
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

        public int Add(MealIngredient entity)
        {
            if(!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<int>(MealIngredientQueries.Add
                                                              , new
                                                              {
                                                                  meal = entity.MealId,
                                                                  ingredientId = entity.IngredientId,
                                                                  measure = entity.Measure
                                                              }
                                                              , _dbContext.DbTransaction);
        }

        #region not Implemented
        public IEnumerable<MealIngredient> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public MealIngredient GetByExternalId(string Id)
        {
            throw new System.NotImplementedException();
        }

        public MealIngredient GetById(int Id)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}
