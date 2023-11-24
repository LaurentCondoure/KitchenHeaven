﻿
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

        public const string GetByExternalIdAndRestaurantId =
            @"SELECT
                meal.[id],
                meal.[externalId], 
                meal.[name], 
                meal.[Category], 
                meal.[Area], 
                meal.[instructions], 
                meal.[image], 
                meal.[miniature]
              FROM
                Meal meal
              INNER JOIN
                Menu menu ON menu.mealId = meal.id
              INNER JOIN
                Restaurant restaurant on menu.RestaurantId = restaurant.id
              WHERE
                meal.externalId = @externalId
              AND
                restaurant.id = @restaurantId;";

        public const string Add =
            @"INSERT INTO Meal
                ([externalId], [name], [Category], [Area], [instructions], [image], [miniature])
              VALUES
                (@externalId, @name, @category, @area, @instructions, @image, @miniature);
              select 
                last_insert_rowid();";

        public const string GetByRestaurantId =
            @"SELECT
                meal.id, meal.externalId, meal.[name], meal.[Category], meal.[Area], meal.[image], meal.[miniature]
              FROM
                Meal meal
              INNER JOIN Menu menu
                ON menu.mealId = meal.id
              WHERE
                menu.restaurantId = @restaurantId;
            ";
    }
}
