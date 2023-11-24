using System.Collections.Generic;

using Newtonsoft.Json;

using KitchenHeaven.FrameWork.DataObject.Entities;
using System;
using System.Linq;

namespace KitchenHeaven.FrameWork.DataObject.ApiJsonConvert
{
    /// <summary>
    /// Convert TheMealDb json format in KitchenHeaven entities format 
    /// </summary>
    public class MealJsonConverter : JsonConverter<List<Meal>>
    {
        //TODO : Implement correspondence between API and entity. CHange to dictionnary string string
        private List<string> AcceptedProperties = new List<string>() { "idMeal", "strMeal", "strCategory", "strArea", "strInstructions", "strMealThumb"
                                                                        , "strCategory", "strIngredient", "strMeasure" };


        /// <summary>
        /// Expected json must be the array of meal witch correspond to the"meals" property value . null value accepted
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public override List<Meal>? ReadJson(JsonReader reader, Type objectType, List<Meal>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return new List<Meal>();

            if (reader.TokenType != JsonToken.StartArray)
                throw new Exception("json format is not valid");

            List<Meal> lstMeals = new List<Meal>();

            Dictionary<string, string> apiMealProperties = null;
            string currentProperty = null;
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.EndArray && apiMealProperties != null)
                    throw new Exception("json format is not valid");
                if (reader.TokenType == JsonToken.PropertyName && apiMealProperties == null)
                    throw new Exception("json format is not valid");
                if (reader.TokenType == JsonToken.StartObject && apiMealProperties != null)
                    throw new Exception("json format is not valid");
                if (reader.TokenType == JsonToken.EndObject && apiMealProperties == null)
                    throw new Exception("json format is not valid");
                //if (reader.TokenType == JsonToken.String && string.IsNullOrWhiteSpace(currentProperty))
                //    throw new Exception("json format is not valid");

                if (reader.TokenType == JsonToken.EndArray)
                {
                    break;
                }

                if (reader.TokenType == JsonToken.StartObject)
                {
                    apiMealProperties = new Dictionary<string, string>();
                    continue;
                }

                if (reader.TokenType == JsonToken.PropertyName)
                {
                    if (AcceptedProperties.Count(c => reader.Value.ToString().StartsWith(c)) > 0)
                    {
                        currentProperty = reader.Value.ToString();
                    }
                    continue;
                }

                if (reader.TokenType == JsonToken.String && !string.IsNullOrWhiteSpace(currentProperty))
                {
                    apiMealProperties.Add(currentProperty, reader.Value.ToString());
                    currentProperty = null;
                    continue;
                }


                if (reader.TokenType == JsonToken.EndObject)
                {
                    Meal meal = new Meal();
                    if (!apiMealProperties.ContainsKey("idMeal")
                        || !apiMealProperties.ContainsKey("strMeal")
                        || !apiMealProperties.ContainsKey("strMealThumb"))
                        throw new Exception("json is not in the expected format.");

                    meal.ExternalId = apiMealProperties["idMeal"];
                    meal.Name = apiMealProperties["strMeal"];

                    meal.Image = apiMealProperties["strMealThumb"];
                    meal.Miniature = string.Concat(apiMealProperties["strMealThumb"], "/preview");

                    if (apiMealProperties.ContainsKey("strArea"))
                        meal.Area = apiMealProperties["strArea"];
                    if (apiMealProperties.ContainsKey("strCategory"))
                        meal.Category = apiMealProperties["strCategory"];
                    if (apiMealProperties.ContainsKey("strInstructions"))
                        meal.Instructions = apiMealProperties["strInstructions"];

                    IEnumerable<string> ingredientkeys = apiMealProperties.Keys.Where(k => k.StartsWith("strIngredient"));
                    List<Ingredient> ingredients = new List<Ingredient>();
                    foreach (string ingredientKey in ingredientkeys)
                    {
                        if (!string.IsNullOrWhiteSpace(apiMealProperties[ingredientKey]))
                        {
                            string measureKey = ingredientKey.Replace("strIngredient", "strMeasure");
                            string ingredientMeasure = apiMealProperties[ingredientKey];
                            ingredients.Add(new Ingredient()
                            {
                                Name = apiMealProperties[ingredientKey],
                                Measure = apiMealProperties.ContainsKey(measureKey) ? apiMealProperties[measureKey] : string.Empty
                            });
                        }
                    }
                    meal.Ingredients = ingredients;

                    lstMeals.Add(meal);
                    apiMealProperties.Clear();
                    apiMealProperties = null;
                }
            }
            
            return lstMeals;
        }

        public override void WriteJson(JsonWriter writer, List<Meal>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

    }
}
