using KitchenHeaven.FrameWork.DataAccess.Factories;
using KitchenHeaven.FrameWork.DataAccess.UOW;
using KitchenHeaven.FrameWork.Service.Interface;

namespace KitchenHeaven.FrameWork.Service.Services
{
    public class MealService : IMealService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAPIAccessFactory _aPIAccessFactory;

        private readonly string connectionString;

        public MealService(IUnitOfWork unitOfWork, IAPIAccessFactory iAPIAccessFactory)
        {
            _unitOfWork = unitOfWork;
            _aPIAccessFactory = iAPIAccessFactory;
        }
    }
}
