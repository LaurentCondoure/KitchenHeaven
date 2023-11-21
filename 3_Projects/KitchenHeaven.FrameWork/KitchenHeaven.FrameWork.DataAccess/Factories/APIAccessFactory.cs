using KitchenHeaven.FrameWork.DataAccess.DataAccess;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Factories
{
    public class APIAccessFactory : IAPIAcessFactory
    {

        public IMealAPIAccess CreateAPIAccess(FilterType filterType)
        {
            switch (filterType)
            {
                case FilterType.Area:
                    return new MealAreaAPIAccess();
                case FilterType.Name:
                    return new MealAPIAcess();
                case FilterType.Ingredient:
                    return new MealIngredientAPIAccess();
                case FilterType.Category:
                    return new MealCategoryAPIAccess();
                // Services validate input data, this case shouldn't happen
                default:
                    return null;
            }
        }
    }
}
