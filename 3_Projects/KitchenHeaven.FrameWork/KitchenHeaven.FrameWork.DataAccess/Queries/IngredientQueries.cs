using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public class IngredientQueries
    {
        public const string GetById =
            @"SELECT
                *
              FROM
                Ingredient
              WHER
                id = @id;           
            ";

        public const string GetByIds =
            @"SELECT
                *
              FROM
                Ingredient
              WHER
                id in (@ids);           
            ";

        public const string Add =
            @"INSERT INTO Ingredient
                ([ExternalId], [Name], [Description])
              VALUES
                (@externalId, @name, @description);
              select 
                last_insert_rowid();
            ";

        public const string GetByMealId =
            @"SELECT
                ingredient.Name,ingredient.description, mealIngredient.measure
              FROM
                Ingredient ingredient
              INNER JOIN
                MealIngredient mealIngredient on ingredient.id = mealIngredient.Id
              WHERE
                mealIngredient.mealId = @mealId;
            ";
            
    }
}
