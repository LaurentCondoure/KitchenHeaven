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

        public static string SearchRestaurant =>
            @"
                SELECT
                    *
                FROM
                    Restaurant
                WHERE
                    @name is null OR (@name is not null and name like @name)
                OR
                    @businessIdentifier is null OR (@businessIdentifier is not null and businessIdentifier like @businessidentifier )
                OR
                    @Adress is null OR (@adress is not null and (adress like @adress  OR  adressComplement like @adress))
                OR
                    @city is null OR (@city is not null and (cityCode like @cityCode  OR  cityName like @cityName))

            ";

        public static string Add =>
            @"INSERT INTO Restaurant
                ([name], [businessIdentifier], [adress], [adressComplement], [cityCode], [cityName], [manager])
              Values
                (@name, @businessIdentifier, @adress, @adressComplement, @cityCode, @cityName, @manager);
            ";

    }
}
