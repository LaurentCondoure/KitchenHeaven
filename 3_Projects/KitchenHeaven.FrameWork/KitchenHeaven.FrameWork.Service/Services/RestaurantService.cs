using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.Service.Services
{
    /// <summary>
    /// Class implementing business method related to restaurant
    /// </summary>
    public class RestaurantService : IRestaurantService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMenuService _menuService;

        private readonly string connectionString;

        private readonly IConfigurationRoot _configurationRoot;



        public RestaurantService(IUnitOfWork unitOfWork, IMenuService menuService)
        {
            _unitOfWork = unitOfWork;
            _menuService = menuService;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            IEnumerable<Restaurant> restaurants = null;

            _unitOfWork.Begin(connectionString, false);

            try
            {
                restaurants = _unitOfWork.GetRestaurantDataAccess().GetAll();

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
            return restaurants;
        }

        public IEnumerable<Restaurant> GetAllByCriteria(RestaurantSearchCriteria restaurantSearchCriteria)
        {
            IEnumerable<Restaurant> restaurants = null;

            _unitOfWork.Begin(connectionString, false);

            try
            {
                restaurants = _unitOfWork.GetRestaurantDataAccess().GetAllByCriteria(restaurantSearchCriteria);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
            return restaurants;
        }

        public Restaurant GetById(int restaurantId)
        {
            if (restaurantId <= 0)
                throw new ArgumentException("externalId is not valid");
            
            Restaurant restaurant = null;

            _unitOfWork.Begin(connectionString, false);

            try
            {
                restaurant = _unitOfWork.GetRestaurantDataAccess().GetById(restaurantId);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
            return restaurant;
        }


    }
}
