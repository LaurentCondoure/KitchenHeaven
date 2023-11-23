using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.DataAccess.Interfaces
{
    public interface IIngredientDataAccess : IBaseDataAccess<Ingredient>
    {
        IEnumerable<Ingredient> GetIngredientsByMealId(int mealId);
    }
}
