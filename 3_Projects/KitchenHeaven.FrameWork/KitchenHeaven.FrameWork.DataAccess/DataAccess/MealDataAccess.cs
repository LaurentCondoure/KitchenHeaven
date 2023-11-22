using System;
using System.Data;
using Dapper;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealDataAccess : IMealDataAccess
    {
        private readonly IDbContext _dbContext;

        public MealDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Add(Meal entity)
        {
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

        public Meal GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

        public Meal GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
