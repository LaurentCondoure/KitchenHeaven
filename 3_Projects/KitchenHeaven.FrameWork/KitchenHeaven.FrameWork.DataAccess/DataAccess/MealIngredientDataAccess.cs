using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;
using System.Data;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealIngredientDataAccess : IMealIngredientDataAccess
    {
        #region private properties
        private IDbConnection _dbConnection;
        #endregion

        public void SetDbContext(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public int Add(MealIngredient entity)
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
