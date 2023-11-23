using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IMenuDataAccess : IBaseDataAccess<Menu>
    {
        int CheckMealInMenu(string mealExternalId);
    }
}
