using KitchenHeaven.FrameWork.DataObject.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.Service.Interfaces
{
    public interface IRestaurantService
    {
        IEnumerable<Restaurant> GetAll();

        IEnumerable<Restaurant> GetAllByCriteria(RestaurantSearchCriteria restaurantSearchCriteria);


    }
}
