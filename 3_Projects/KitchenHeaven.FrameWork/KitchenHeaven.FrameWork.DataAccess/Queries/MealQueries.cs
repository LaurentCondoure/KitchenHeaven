using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class MealQueries
    {
        public static string MealById =>
            @"SELECT
                *
              FROM
                Meal
              WHERE
                id = @id";

        public static string MealByExternalId =>
            @"SELECT
                *
              FROM
                Meal
              WHERE
                externalId = @externalId;";

        public static string AddMeal =>
            @"INSERT INTO Meal
                ([externalId], [name], [Category], [Area], [instructions], [image])
              VALUES
                (@externalId, @name, @category, @area, @instructions, @image);";
    }
}
