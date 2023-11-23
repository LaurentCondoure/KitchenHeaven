using System;
using System.Collections.Generic;
using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    public class RestaurantDataAccess : IRestaurantDataAccess
    {
        private IDbContext _dbContext;

        private const string WildCard = "%";

        public RestaurantDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int Id)
        {
            return _dbContext.DbConnection.ExecuteScalar<Restaurant>(RestaurantQueries.GetById
                                                                        , new { id = Id}
                                                                        , _dbContext.DbTransaction );
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.DbConnection.Query<Restaurant>(RestaurantQueries.GetAll
                                                            , transaction: _dbContext.DbTransaction);
        }

        public IEnumerable<Restaurant> GetAllByCriteria(RestaurantSearchCriteria restaurantSearchCriteria)
        {
            return _dbContext.DbConnection.Query<Restaurant>(RestaurantQueries.Search
                                                                , new
                                                                {
                                                                    name = string.Concat(restaurantSearchCriteria.Name, WildCard),
                                                                    businessIfdentifier = string.Concat(restaurantSearchCriteria.Name, WildCard),
                                                                    address = string.Concat(restaurantSearchCriteria.Address, WildCard),
                                                                    addressComplement = string.Concat(restaurantSearchCriteria.AddressComplement, WildCard),
                                                                    city = restaurantSearchCriteria.CityCode,
                                                                    cityName = restaurantSearchCriteria.CityName,
                                                                });
        }
    }
}
