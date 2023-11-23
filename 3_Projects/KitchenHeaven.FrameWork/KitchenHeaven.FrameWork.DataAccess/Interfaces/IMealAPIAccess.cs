using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IMealAPIAccess
    {
        MealFilterValue GetFilters();

        ICollection<Meal> SearchMeals(MealFilterValue mealFilterValue);

        Meal GetMeal(int id);
    }
}
