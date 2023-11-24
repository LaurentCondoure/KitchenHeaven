using System;
using System.Collections.Generic;
using System.Data;

using Dapper;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.Queries;
using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Classe instaciating methods to exchange data with DataBase focus on Restauarnt Entity
    /// </summary>
    public class RestaurantDataAccess : IRestaurantDataAccess
    {
        private IDbContext _dbContext;

        private const string WildCard = "%";

        public RestaurantDataAccess(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool CheckDbContext()
        {
            if (_dbContext == null || (_dbContext.DbConnection == null || _dbContext.DbConnection.State != ConnectionState.Open))
                return false;
            else
                return true;
        }

        public int Add(Restaurant entity)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.ExecuteScalar<int>(RestaurantQueries.Add
                                                                , new
                                                                {
                                                                    name = entity.Name,
                                                                    businessIdentifier = entity.BusinessIdentifier,
                                                                    address = entity.Address,
                                                                    addressComplement = entity.AddressComplement,
                                                                    cityCode = entity.CityCode,
                                                                    cityName = entity.CityName,
                                                                    manager = entity.Manager
                                                                }
                                                                , _dbContext.DbTransaction);
        }

        public Restaurant GetById(int Id)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.QueryFirst<Restaurant>(RestaurantQueries.GetById
                                                                        , new { id = Id}
                                                                        , _dbContext.DbTransaction );
        }

        public IEnumerable<Restaurant> GetAll()
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.Query<Restaurant>(RestaurantQueries.GetAll
                                                            , transaction: _dbContext.DbTransaction);
        }

        public IEnumerable<Restaurant> GetAllByCriteria(RestaurantSearchCriteria restaurantSearchCriteria)
        {
            if (!CheckDbContext())
                throw new Exception("Database connection is not initialized");
            return _dbContext.DbConnection.Query<Restaurant>(RestaurantQueries.Search
                                                                , new
                                                                {
                                                                    name = string.Concat(restaurantSearchCriteria.Name, WildCard),
                                                                    businessIdentifier = string.Concat(restaurantSearchCriteria.Name, WildCard),
                                                                    address = string.Concat(restaurantSearchCriteria.Address, WildCard),
                                                                    addressComplement = string.Concat(restaurantSearchCriteria.AddressComplement, WildCard),
                                                                    cityCode = restaurantSearchCriteria.CityCode,
                                                                    cityName = restaurantSearchCriteria.CityName,
                                                                    manager = restaurantSearchCriteria.Manager
                                                                },
                                                                _dbContext.DbTransaction);
        }

        public Restaurant GetByExternalId(string Id)
        {
            throw new NotImplementedException();
        }

    }
}
