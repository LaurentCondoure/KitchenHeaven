using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class MenuQueries
    {
        public static string GetMealByExternalId =>
            @"SELECT
                meal.id
              FROM
                Menu m
              INNER Join
                Meal me ON m.mealId = m.id
              Where 
                me.externatId = @externalId;
            ";

        public static string Add =>
            @"INSERT INTO Menu
                (restaurantId, mealId)
              VALUS
                (@restaurantId, @mealId);
            ";

    }
}
