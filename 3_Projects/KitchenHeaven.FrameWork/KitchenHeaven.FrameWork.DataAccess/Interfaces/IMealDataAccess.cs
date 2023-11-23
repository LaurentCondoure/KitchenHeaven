using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IMealDataAccess : IBaseDataAccess<Meal>
    {
        Meal GetByExternalIdAndRestaurantId(string externalId, int restaurantId);

        IEnumerable<Meal> GetByRestaurantId(int restaurantId);
    }
}
