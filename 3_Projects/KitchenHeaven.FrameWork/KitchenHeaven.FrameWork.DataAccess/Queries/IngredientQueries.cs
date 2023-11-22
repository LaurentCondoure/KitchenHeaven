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
    }
}
