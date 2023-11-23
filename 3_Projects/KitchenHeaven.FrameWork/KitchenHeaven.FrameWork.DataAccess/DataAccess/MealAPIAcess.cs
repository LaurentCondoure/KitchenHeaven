using System;
using System.Collections.Generic;

using Microsoft.Extensions.Options;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess
{
    public class MealAPIAcess : IMealAPIAccess
    {
        private IOptionsSnapshot<APIConfiguration> _options;
        public MealAPIAcess(IOptionsSnapshot<APIConfiguration> options)
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
