using System;
using System.Collections.Generic;

using Microsoft.Extensions.Options;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Configuration;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealCategoryAPIAccess : IMealAPIAccess
    {
        private IOptionsSnapshot<APIConfiguration> _options;
        public MealCategoryAPIAccess(IOptionsSnapshot<APIConfiguration> options)
        {
            _options = options;
        }


        public MealFilterValue GetFilters()
        {
            throw new NotImplementedException();
        }

        public Meal GetMeal(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            throw new NotImplementedException();
        }
    }
}
