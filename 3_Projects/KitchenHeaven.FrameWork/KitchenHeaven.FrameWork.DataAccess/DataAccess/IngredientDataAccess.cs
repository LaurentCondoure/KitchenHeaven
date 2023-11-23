using System;
using System.Collections.Generic;
using System.Data;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class IngredientDataAccess : IIngredientDataAccess
    {
        private IDbContext _dbContext;
        public IngredientDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        #region IIngredientDataAccess
        public int Add(Ingredient entity)
        {
            
            return _dbContext.DbConnection.ExecuteScalar<int>(IngredientQueries.Add
                                                              , new {
                                                                  externalId = entity.ExternalId,
                                                                  name = entity.Name,
                                                                  description = entity.Description}
                                                              , _dbContext.DbTransaction);
        }

        public bool CheckDbContext()
        {
            if (_dbContext == null || (_dbContext.DbConnection == null || _dbContext.DbConnection.State != ConnectionState.Open))
                return false;
            else
                return true;
        }

        public IEnumerable<Ingredient> GetAll()
        {
            throw new NotImplementedException();
        }

        public Ingredient GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ingredient> GetIngredientsByMealId(int mealId)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.Query<Ingredient>(IngredientQueries.GetByMealId
                                                            , new { mealId = mealId }
                                                            , _dbContext.DbTransaction);
        }
        #endregion

    }
}
