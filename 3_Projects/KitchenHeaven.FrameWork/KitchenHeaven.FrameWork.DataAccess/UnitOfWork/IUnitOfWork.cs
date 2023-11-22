using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.UOW
{
    public interface IUnitOfWork
    {
        IIngredientDataAccess IngredientDataAccess { get; }
        IMealDataAccess MealDataAccess { get; }
        IMealIngredientDataAccess MealIngredientDataAccess { get; }
        IMenuDataAccess MenuDataAccess { get; }
        IRestaurantDataAccess RestaurantDataAccess { get; }
        void Commit();
        void Rollback();

    }
}
