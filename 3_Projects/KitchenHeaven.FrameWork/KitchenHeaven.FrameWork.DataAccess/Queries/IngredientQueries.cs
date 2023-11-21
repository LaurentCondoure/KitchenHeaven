using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public class IngredientQueries
    {
        public static string GetById =>
            @"SELECT
                *
              FROM
                Ingredient
              WHER
                id = @id;           
            ";

        public static string GetByIds =>
            @"SELECT
                *
              FROM
                Ingredient
              WHER
                id in (@ids);           
            ";

        public static string Add => 
            @"INSERT INTO Ingredient
                ([ExternalId], [Name], [Description])
              VALUES
                (@externalId, @name, @description);
            ";
    }
}
