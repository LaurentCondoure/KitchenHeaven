using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;
using KitchenHeaven.FrameWork.Service.Interfaces;

namespace KitchenHeaven.FrameWork.Service.Services
{
    /// <summary>
    /// Class implementing business method related to menu
    /// </summary>
    public class MenuService : IMenuService
    {
        #region private properties
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAPIAccessFactory _aPIAccessFactory;

        private readonly string connectionString;

        #endregion

        public MenuService(IUnitOfWork unitOfWork, IAPIAccessFactory iAPIAccessFactory)
        {
            _unitOfWork = unitOfWork;
            _aPIAccessFactory = iAPIAccessFactory;
        }

        #region IMenuService

        public bool AddMeal(int restaurantId, string externalId)
        {
            if (restaurantId <= 0)
                throw new ArgumentException("restaurantId is not valid");
            if (string.IsNullOrWhiteSpace(externalId))
                throw new ArgumentException("meal externalId is not valid");

            _unitOfWork.Begin(connectionString, false);
            Restaurant restaurant = _unitOfWork.GetRestaurantDataAccess().GetById(restaurantId);
            int mealId = _unitOfWork.GetMenuDataAccess().CheckMealInMenu(externalId);
            _unitOfWork.Commit();

            if (restaurant == null)
                throw new Exception("Restaurant does not exists");

            if (mealId > 0)
                throw new Exception("meal already in Restaurant's menu");

            Meal apiMeal = null;
            Meal dbMeal = null;

            Task<Meal> taskMealApi = GetMealFromAPI(externalId);
            Task<Meal> taskMealDb = GetMealFromDatabase(externalId);
            taskMealApi.Start();
            taskMealDb.Start();
            taskMealApi.Wait();
            taskMealDb.Wait();

            apiMeal = taskMealApi.Result;
            dbMeal = taskMealDb.Result;

            if (apiMeal == null && dbMeal == null)
                throw new Exception("Meal cannot be retrieve or is unknown");

            int insertedMealId = -1;
            if (dbMeal == null)
            {
                try
                {
                    _unitOfWork.Begin(connectionString, true);
                    insertedMealId = _unitOfWork.GetMealDataAccess().Add(apiMeal);
                    if (insertedMealId <= 0)
                        throw new Exception("Meal is not inserted in database");
                    apiMeal.Ingredients.ForEach(ingredient =>
                    {
                        Ingredient ingredientDb = _unitOfWork.GetIngredientDataAccess().GetByExternalId(ingredient.ExternalId);
                        int ingredientId = -1;
                        if (ingredientDb != null)
                            ingredientId = ingredientDb.id;
                        else
                            ingredientId = _unitOfWork.GetIngredientDataAccess().Add(ingredient);

                        _unitOfWork.GetMealIngredientDataAccess().Add(new MealIngredient() {
                            IngredientId = ingredientId,
                            MealId = insertedMealId,
                            Measure = ingredient.Measure,
                        }
                                                                    );
                    });
                    _unitOfWork.Commit();
                }
                catch
                {
                    _unitOfWork.Rollback();
                }
            }

            try
            {
                _unitOfWork.Begin(connectionString, false);
                int insertedMealMenu = _unitOfWork.GetMenuDataAccess().Add(new Menu()
                {
                    MealId = insertedMealId < 0 ? dbMeal.Id : insertedMealId,
                    RestaurantId = restaurantId
                }
                                                    );
                IEnumerable<Meal> meals = _unitOfWork.GetMealDataAccess().GetByRestaurantId(restaurantId);
                _unitOfWork.Commit();
                if (insertedMealMenu > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }
        }

        public IEnumerable<Meal> AddMeal(int restaurantId, List<string> mealExternalIds, out Dictionary<string, string> results)
        {
            results = new Dictionary<string, string>();
            if (mealExternalIds.Count == 0)
                throw new ArgumentException("no meal to add");

            foreach (string mealexternalId in mealExternalIds)
            {
                try
                {
                    if (AddMeal(restaurantId, mealexternalId))
                        results.Add(mealexternalId, "OK");
                    else
                        results.Add(mealexternalId, "KO");
                }
                catch (Exception ex)
                {
                    results.Add(mealexternalId, $"{ex.GetBaseException().GetType()}:{ex.Message}");
                }
            }
            _unitOfWork.Begin(connectionString, false);
            IEnumerable<Meal> menu = _unitOfWork.GetMealDataAccess().GetByRestaurantId(restaurantId);
            _unitOfWork.Commit();
            return menu;
        }

        public IEnumerable<Meal> AddMeal(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public bool CheckMeal(string externalId)
        {
            int mealIdinMenu = -1;
            _unitOfWork.Begin(connectionString, false);

            try
            {
                mealIdinMenu = _unitOfWork.GetMenuDataAccess().CheckMealInMenu(externalId);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return mealIdinMenu > 0;
        }

        public IEnumerable<Meal> GetMenu(int restaurantId)
        {
            IEnumerable<Meal> menu = null;
            _unitOfWork.Begin(connectionString, false);

            try
            {
                menu = _unitOfWork.GetMealDataAccess().GetByRestaurantId(restaurantId);

                _unitOfWork.Commit();
            }
            catch
            {
                _unitOfWork.Rollback();
                throw;
            }

            return menu;
        }


        #endregion

        #region private methods

        private async Task<Meal> GetMealFromAPI(string externalId)
        {
            IMealAPIAccess mealAPIAccess = _aPIAccessFactory.CreateAPIAccess(FilterType.Meal);
            return mealAPIAccess.GetMeal(externalId);
        }

        private async Task<Meal> GetMealFromDatabase(string externalId)
        { 
            _unitOfWork.Begin(connectionString, false);
            Meal dbMeal = _unitOfWork.GetMealDataAccess().GetByExternalId(externalId);
            _unitOfWork.Commit();
            return dbMeal;
        }

        #endregion
    }
}
