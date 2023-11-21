using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class MealIngredientQueries
    {
        public static string Add =>
            @"
                INSERT INTO MealIngredients
                    ([mealId], [ingredientId], [measure])
                VALUES
                    (@mealId, @ingredientId, @measure);
            ";
    }
}
