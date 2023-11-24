using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Configuration;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.ApiJsonConvert;


namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Classe instaciating methods to call TheMealDb API focus on Name or Id
    /// </summary>
    public class MealAPIAcess : BaseAPIAccess, IMealAPIAccess
    {
        private IAPIConfiguration _options;

        public MealAPIAcess(IAPIConfiguration options)
        {
            _options = options;
        }


        /// <summary>
        /// Search a meal by his id on TheMealDb
        /// </summary>
        /// <param name="mealFilterValue"></param>
        /// <returns>List of meal</returns>
        public Meal GetMeal(string id)
        {
            string GetMealsByName = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.Meal.APIIdFilterMethod}?{_options.Meal.APIIdArgument}={id}");
            string returnedMeals = RequestMealDbAPI(GetMealsByName);
            if(string.IsNullOrEmpty(returnedMeals))
                return new Meal();
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new MealJsonConverter());

            dynamic mealsJson = JsonConvert.DeserializeObject(returnedMeals);
            var mealValues = JsonConvert.SerializeObject(mealsJson.meals);
            List<Meal> msg2 = JsonConvert.DeserializeObject<List<Meal>>(mealValues, jsonSerializerSettings);

            return msg2.FirstOrDefault();
        }

        /// <summary>
        /// Search a meal using the name filter of TheMealDb
        /// </summary>
        /// <param name="mealFilterValue"></param>
        /// <returns>List of meal</returns>
        public IEnumerable<Meal> SearchMeals(MealFilterValue mealFilterValue)
        {
            string GetMealsByName = String.Join(@"/", _options.General.APIUrl.TrimEnd('/'), _options.General.APIKey, $"{_options.Meal.APINameFilterMethod}?{_options.Meal.APINameArgument}={mealFilterValue.Name}");
            string returnedMeals = RequestMealDbAPI(GetMealsByName);
            if (string.IsNullOrWhiteSpace(returnedMeals))
                return new List<Meal>();
            JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new MealJsonConverter());

            dynamic mealsJson = JsonConvert.DeserializeObject(returnedMeals);
            var mealValues = JsonConvert.SerializeObject(mealsJson.meals);
            List<Meal> msg2 = JsonConvert.DeserializeObject<List<Meal>>(mealValues, jsonSerializerSettings);

            return msg2;
        }

        /// <summary>
        /// Not available for research on name
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public IEnumerable<MealFilterValue> GetFilters()
        {
            throw new NotImplementedException();
        }
    }
}
