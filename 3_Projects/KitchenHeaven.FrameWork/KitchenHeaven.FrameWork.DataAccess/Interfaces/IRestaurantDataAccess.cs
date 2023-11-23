using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IRestaurantDataAccess : IBaseDataAccess<Restaurant>
    {
        IEnumerable<Restaurant> GetAllByCriteria(RestaurantSearchCriteria restaurantSearchCriteria);
    }
}
