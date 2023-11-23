using System.Collections.Generic;

using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.Service.Interface
{
    public interface IMenuService
    {
        int AddMeal(int restaurantId, string externalId);

        int AddMeal(Restaurant restaurant);

        bool CheckMeal(string externalId);

        IEnumerable<Meal> GetMenu(int restaurantID);


    }
}
