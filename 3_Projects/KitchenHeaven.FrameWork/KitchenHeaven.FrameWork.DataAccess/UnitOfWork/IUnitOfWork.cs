using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        public IIngredientDataAccess GetIngredientDataAccess();
        public IMealDataAccess GetMealDataAccess();
        public IMealIngredientDataAccess GetMealIngredientDataAccess();
        public IMenuDataAccess GetMenuDataAccess();
        public IRestaurantDataAccess GetRestaurantDataAccess();

        void Begin(string connectionString, bool useTransaction);
        void Commit();
        void Rollback();

    }
}
