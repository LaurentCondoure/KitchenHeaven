﻿using System;
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
                OR
                    @businessIdentifier is null OR (@businessIdentifier is not null AND businessIdentifier like @businessidentifier )
                OR
                    @address is null OR (@address is not null AND (Address like @address))
                OR
                    @addressComplement is null OR (@addressComplement is not null AND (AddressComplement like @addressComplement))
                OR
                    @cityCode is null OR (@cityCode is not null AND (cityCode like @cityCode))
                OR
                    @cityName is null OR (@cityName is not null AND (cityNam like @cityName))

            ";

        public const string Add =
            @"INSERT INTO Restaurant
                ([name], [businessIdentifier], [Address], [AddressComplement], [cityCode], [cityName], [manager])
              Values
                (@name, @businessIdentifier, @address, addressComplement, @cityCode, @cityName, @manager);
            ";

        public const string GetAll = 
            @"SELECT
                *
              FROM
                Restaurant";
    }
}
