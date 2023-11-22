using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class MenuQueries
    {
        public const string GetMealByExternalId =
            @"SELECT
                meal.id
              FROM
                Menu m
              INNER Join
                Meal me ON m.mealId = m.id
              Where 
                me.externatId = @externalId;
            ";

        public const string Add =
            @"INSERT INTO Menu
                (restaurantId, mealId)
              VALUS
                (@restaurantId, @mealId);
            ";

    }
}
