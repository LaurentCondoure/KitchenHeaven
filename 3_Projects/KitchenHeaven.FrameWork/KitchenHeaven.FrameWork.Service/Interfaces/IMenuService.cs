using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.Service.Interfaces
{
    public interface IMenuService
    {
        bool AddMeal(int restaurantId, string externalId);

        IEnumerable<Meal> AddMeal(int restaurantId, List<string> externalId, out Dictionary<string, string> results);

        IEnumerable<Meal> AddMeal(Restaurant restaurant);

        bool CheckMeal(string externalId);

        IEnumerable<Meal> GetMenu(int restaurantId);


    }
}
