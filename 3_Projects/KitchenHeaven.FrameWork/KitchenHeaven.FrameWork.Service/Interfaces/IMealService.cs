using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;


namespace KitchenHeaven.FrameWork.Service.Interfaces
{
    public interface IMealService
    {
        IEnumerable<MealFilterValue> GetFilters(FilterType filterType);

        Meal ConsultMeal(string externalId, int restaurantId);

        IEnumerable<Meal> Search(MealFilterValue filterValue);


    }
}
