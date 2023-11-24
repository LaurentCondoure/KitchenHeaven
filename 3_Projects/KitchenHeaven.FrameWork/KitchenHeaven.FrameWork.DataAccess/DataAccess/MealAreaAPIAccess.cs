using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.ApiJsonConvert;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Class implementing methods to call TheMealDb API focus on Area interactions
    /// </summary>
    public class MealAreaAPIAccess : BaseAPIAccess, IMealAPIAccess
    {
        private IAPIConfiguration _options;
        public MealAreaAPIAccess(IAPIConfiguration options)
        {
            _options = options;
        }

        /// <summary>
        /// Get All Area Filter
        /// </summary>
        /// <returns>
        /// List of filterValue containing areas'name
        /// </returns>
        public IEnumerable<MealFilterValue> GetFilters()
        {
            string GetMealsDetailByIdAPI = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.MealArea.APIListMethod}?{_options.MealArea.APIArgument}=list");
            string returnedMeals = RequestMealDbAPI(GetMealsDetailByIdAPI);
            if (string.IsNullOrEmpty(returnedMeals))
                return null;
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new AreaJsonConverter());

            dynamic msg = JsonConvert.DeserializeObject(returnedMeals);
            var mealFilter = JsonConvert.SerializeObject(msg.meals);
            List<MealFilterValue> msg2 = JsonConvert.DeserializeObject<List<MealFilterValue>>(mealFilter, jsonSerializerSettings);

            return msg2;

        }


        /// <summary>
        /// Search a meal using the area filter of TheMealDb
        /// </summary>
        /// <param name="mealFilterValue"></param>
        /// <returns>List of meal</returns>
        public IEnumerable<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            string GetMealsDetailByIdAPI = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.MealArea.APIFilterMethod}?{_options.MealArea.APIArgument}={mealFilterValue.Name}");
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
        /// Not available for Area
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public Meal GetMeal(string id)
        {
            throw new NotImplementedException();
        }
    }
}
