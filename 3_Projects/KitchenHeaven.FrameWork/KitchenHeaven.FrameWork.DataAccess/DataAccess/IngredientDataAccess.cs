using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;
using System;
using Dapper;
using System.Collections.Generic;
using System.Text;
using KitchenHeaven.FrameWork.DataAccess.Queries;

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

        public Ingredient GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

        public Ingredient GetById(int Id)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
