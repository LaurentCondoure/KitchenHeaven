using Microsoft.Extensions.Options;

using KitchenHeaven.FrameWork.DataAccess.DataAccess;
using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Enums;


namespace KitchenHeaven.FrameWork.DataAccess.Factories
{
    public class APIAccessFactory : IAPIAcessFactory
    {
        private IOptionsSnapshot<APIConfiguration> _options;
        public APIAccessFactory(IOptionsSnapshot<APIConfiguration> options)
        { 
            _options = options;
        }


        public IMealAPIAccess CreateAPIAccess(FilterType filterType)
        {
            switch (filterType)
            {
                case FilterType.Area:
                    return new MealAreaAPIAccess(_options);
                case FilterType.Name:
                    return new MealAPIAcess(_options);
                case FilterType.Ingredient:
                    return new MealIngredientAPIAccess(_options);
                case FilterType.Category:
                    return new MealCategoryAPIAccess(_options);
                // Services validate input data, this case shouldn't happen
                default:
                    return null;
            }
        }
    }
}
