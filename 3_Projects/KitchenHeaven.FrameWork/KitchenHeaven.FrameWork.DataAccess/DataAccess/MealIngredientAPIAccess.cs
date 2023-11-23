using System.Collections.Generic;

using Microsoft.Extensions.Options;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealIngredientAPIAccess : IMealAPIAccess
    {
        private IOptionsSnapshot<APIConfiguration> _options;
        public MealIngredientAPIAccess(IOptionsSnapshot<APIConfiguration> options)
        {
            _options = options;
        }

        public MealFilterValue GetFilters()
        {
            throw new System.NotImplementedException();
        }

        public Meal GetMeal(int id)
        {
            throw new System.NotImplementedException();
        }

        public ICollection<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            throw new System.NotImplementedException();
        }
    }
}
