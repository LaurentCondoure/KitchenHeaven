using System;
using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;
using Microsoft.Extensions.Options;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealAreaAPIAccess : IMealAPIAccess
    {
        private IOptionsSnapshot<APIConfiguration> _options;
        public MealAreaAPIAccess(IOptionsSnapshot<APIConfiguration> options)
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
