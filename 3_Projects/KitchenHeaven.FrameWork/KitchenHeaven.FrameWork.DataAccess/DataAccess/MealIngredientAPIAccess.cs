
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealIngredientAPIAccess : IMealAPIAccess
    {
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
