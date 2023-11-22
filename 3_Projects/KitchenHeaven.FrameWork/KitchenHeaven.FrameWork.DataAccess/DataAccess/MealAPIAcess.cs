using System;
using System.Collections.Generic;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities;

namespace KitchenHeaven.FrameWork.DataAccess
{
    public class MealAPIAcess : IMealAPIAccess
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
