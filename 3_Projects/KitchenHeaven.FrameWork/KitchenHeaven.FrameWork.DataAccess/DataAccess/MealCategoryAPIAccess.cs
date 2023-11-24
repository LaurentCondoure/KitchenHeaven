using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.ApiJsonConvert;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Class implementing methods to call TheMealDb API focus on Category interactions
    /// </summary>
    public class MealCategoryAPIAccess : BaseAPIAccess, IMealAPIAccess
    {
        //TODO : add IMealAreaAPIConfiguration
        private IAPIConfiguration _options;
        public MealCategoryAPIAccess(IAPIConfiguration options)
        {
            _options = options;
        }

        /// <summary>
        /// Get All Category Filter
        /// </summary>
        /// <returns>
        /// List of filterValue containing category'name
        /// </returns>
        public IEnumerable<MealFilterValue> GetFilters()
        {
            string GetMealsDetailByIdAPI = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.MealCategory.APIListMethod}?{_options.MealCategory.APIArgument}=list");
            string returnedMeals = RequestMealDbAPI(GetMealsDetailByIdAPI);
            if (string.IsNullOrEmpty(returnedMeals))
                return null;
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new CategoryJsonConverter());

            dynamic msg = JsonConvert.DeserializeObject(returnedMeals);
            var mealFilter = JsonConvert.SerializeObject(msg.meals);
            List<MealFilterValue> msg2 = JsonConvert.DeserializeObject<List<MealFilterValue>>(mealFilter);

            return msg2;
        }

        /// <summary>
        /// Search a meal using the category filter of TheMealDb
        /// </summary>
        /// <param name="mealFilterValue"></param>
        /// <returns>List of meal</returns>
        public IEnumerable<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            string GetMealsDetailByIdAPI = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.MealCategory.APIFilterMethod}?{_options.MealCategory.APIArgument}={mealFilterValue.Name}");
            string returnedMeals = RequestMealDbAPI(GetMealsDetailByIdAPI);
            if (string.IsNullOrEmpty(returnedMeals))
                return new List<Meal>();
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new MealJsonConverter());

            dynamic mealsJson = JsonConvert.DeserializeObject(returnedMeals);
            var mealValues = JsonConvert.SerializeObject(mealsJson.meals);
            List<Meal> msg2 = JsonConvert.DeserializeObject<List<Meal>>(mealValues, jsonSerializerSettings);

            return msg2;
        }

        /// <summary>
        /// Not available for category
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public Meal GetMeal(string id)
        {
            throw new NotImplementedException();
        }
    }
}
