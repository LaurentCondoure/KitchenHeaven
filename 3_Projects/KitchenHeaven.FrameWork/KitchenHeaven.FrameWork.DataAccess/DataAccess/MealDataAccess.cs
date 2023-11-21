using System;
using System.Data;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealDataAccess : IMealDataAccess
    {
        private readonly IDbConnection _dbConnection;

        public MealDataAccess(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Add(Meal entity)
        {
            throw new NotImplementedException();
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
