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
    /// Class implementing business method related to Meal
    /// </summary>
    public class MealService : IMealService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAPIAccessFactory _aPIAccessFactory;

        private readonly string connectionString;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork">Imple</param>
        /// <param name="iAPIAccessFactory"></param>
        public MealService(IUnitOfWork unitOfWork, IAPIAccessFactory iAPIAccessFactory)
        {
            _unitOfWork = unitOfWork;
            _aPIAccessFactory = iAPIAccessFactory;
        }

        #region IMealService
        public Meal ConsultMeal(string externalId, int restaurantId)
        {
            if (string.IsNullOrWhiteSpace(externalId))
                throw new ArgumentException("externalId is not valid");

            Meal apiMeal = null;

            try
            {
                IMealAPIAccess mealAPIAccess = _aPIAccessFactory.CreateAPIAccess(FilterType.Meal);
                apiMeal = mealAPIAccess.GetMeal(externalId);
            }
            catch
            {
                if (restaurantId <= 0)
                {
                    throw;
                }
            }

            if (apiMeal != null)
                return apiMeal;


            _unitOfWork.Begin(connectionString, false);
            Meal dbMeal = _unitOfWork.GetMealDataAccess().GetByExternalId(externalId);
            _unitOfWork.Commit();
            return dbMeal;
        }

        public IEnumerable<MealFilterValue> GetFilters(FilterType filterType)
        {
            IMealAPIAccess mealAPIAccess = _aPIAccessFactory.CreateAPIAccess(filterType);
            return mealAPIAccess.GetFilters();
        }

        public IEnumerable<Meal> Search(MealFilterValue filterValue)
        {
            IMealAPIAccess mealAPIAccess = _aPIAccessFactory.CreateAPIAccess(filterValue.FilterType);
            return mealAPIAccess.SearchMeals(filterValue);
        }
        #endregion
    }
}
