using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.Service.Interface;
using System.Collections.Generic;

namespace KitchenHeaven.FrameWork.Service.Services
{
    public class MenuService : IMenuService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAPIAccessFactory aPIAccessFactory;

        private readonly string connectionString;

        public MenuService(IUnitOfWork unitOfWork, IAPIAccessFactory iAPIAccessFactory)
        {
            _unitOfWork = unitOfWork;
        }

        public int AddMeal(int restaurantId, string externalId)
        {
            throw new System.NotImplementedException();
        }

        public int AddMeal(Restaurant restaurant)
        {
            throw new System.NotImplementedException();
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
    }
}
