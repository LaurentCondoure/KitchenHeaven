using KitchenHeaven.FrameWork.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IMealAPIAccess
    {
        MealFilterValue GetFilters();

        ICollection<Meal> SearchMeals(MealFilterValue mealFilterValue);

        Meal GetMeal(int id);
    }
}
