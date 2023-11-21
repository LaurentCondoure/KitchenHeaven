using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class RestaurantQueries
    {
        public static string GetById =>
            @"SELECT
                *
              FROM
                Restautant
              WHERE
                Id = @id";

        public static string Add =>
            @"INSERT INTO Restaurant
                ([name], [businessIdentifier], [adress], [adressComplement], [cityCode], [cityName], [manager])
              Values
                (@name, @businessIdentifier, @adress, @adressComplement, @cityCode, @cityName, @manager);
            ";

    }
}
