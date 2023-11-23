using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IMealAPIAccess
    {
        IEnumerable<MealFilterValue> GetFilters();

        IEnumerable<Meal> SearchMeals(MealFilterValue mealFilterValue);

        Meal GetMeal(string id);
    }
}
