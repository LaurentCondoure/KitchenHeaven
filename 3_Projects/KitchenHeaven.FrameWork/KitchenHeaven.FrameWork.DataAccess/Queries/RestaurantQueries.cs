using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataAccess.Queries
{
    public static class RestaurantQueries
    {
        public const string GetById =
            @"SELECT
                *
              FROM
                Restautant
              WHERE
                Id = @id";

        public const string Search =
            @"
                SELECT
                    *
                FROM
                    Restaurant
                WHERE
                    @name is null OR (@name is not null AND name like @name)
                AND
                    @businessIdentifier is null OR (@businessIdentifier is not null AND businessIdentifier like @businessIdentifier )
                AND
                    @address is null OR (@address is not null AND (Address like @address))
                AND
                    @addressComplement is null OR (@addressComplement is not null AND (AddressComplement like @addressComplement))
                AND
                    @cityCode is null OR (@cityCode is not null AND (cityCode like @cityCode))
                AND
                    @cityName is null OR (@cityName is not null AND (cityName like @cityName))
                AND
                    @manager is null OR (@manager is not null AND manager = @manager)

            ";

        public const string Add =
            @"INSERT INTO Restaurant
                ([name], [businessIdentifier], [Address], [AddressComplement], [cityCode], [cityName], [manager])
              Values
                (@name, @businessIdentifier, @address, @addressComplement, @cityCode, @cityName, @manager);
              select 
                last_insert_rowid();
            ";

        public const string GetAll = 
            @"SELECT
                *
              FROM
                Restaurant";
    }
}
