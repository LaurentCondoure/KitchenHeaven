using System;
using System.Collections.Generic;

using Microsoft.Extensions.Options;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;

namespace KitchenHeaven.FrameWork.DataAccess
{
    public class MealAPIAcess : IMealAPIAccess
    {
        private IOptionsSnapshot<APIConfiguration> _options;

        public MealAPIAcess(IOptionsSnapshot<APIConfiguration> options)
        {
            _options = options;
        }

        public IEnumerable<MealFilterValue> GetFilters()
        {
            throw new NotImplementedException();
        }

        public Meal GetMeal(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            throw new NotImplementedException();
        }
    }
}
