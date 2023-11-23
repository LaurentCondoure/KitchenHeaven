using System.Collections.Generic;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealIngredientDataAccess : IMealIngredientDataAccess
    {
        #region private properties
        private IDbContext _dbContext;
        #endregion

        public MealIngredientDataAccess(IDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public int Add(MealIngredient entity)
        {
            return _dbContext.DbConnection.ExecuteScalar<int>(MealIngredientQueries.Add
                                                              , new
                                                              {
                                                                  meal = entity.MealId,
                                                                  ingredientId = entity.IngredientId,
                                                                  measure = entity.Measure
                                                              }
                                                              , _dbContext.DbTransaction);
        }

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


    }
}
