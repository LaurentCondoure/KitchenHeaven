using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;
using System;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class MealAreaAPIAccess : IMealAPIAccess
    {
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
