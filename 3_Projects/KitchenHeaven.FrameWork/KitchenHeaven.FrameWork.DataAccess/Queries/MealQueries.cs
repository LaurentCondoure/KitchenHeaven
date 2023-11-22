using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class MealQueries
    {
        public const string GetById =
            @"SELECT
                *
              FROM
                Meal
              WHERE
                id = @id";

        public const string GetByExternalId =
            @"SELECT
                *
              FROM
                Meal
              WHERE
                externalId = @externalId;";

        public const string Add =
            @"INSERT INTO Meal
                ([externalId], [name], [Category], [Area], [instructions], [image])
              VALUES
                (@externalId, @name, @category, @area, @instructions, @image);";
    }
}
