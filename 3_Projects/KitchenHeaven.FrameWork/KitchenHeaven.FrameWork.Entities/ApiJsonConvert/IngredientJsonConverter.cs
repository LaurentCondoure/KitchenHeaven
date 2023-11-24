using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using KitchenHeaven.FrameWork.DataObject.Entities;
using System.Linq;

namespace KitchenHeaven.FrameWork.DataObject.ApiJsonConvert
{
    public class IngredientJsonConverter : JsonConverter<List<MealFilterValue>>
    {
        //TODO : Implement correspondence between API and entity. CHange to dictionnary string string
        private List<string> AcceptedProperties = new List<string>() { "idIngredient", "strIngredient", "strDescription"};


        public override List<MealFilterValue>? ReadJson(JsonReader reader, Type objectType, List<MealFilterValue>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            if (reader.TokenType != JsonToken.StartArray)
                throw new Exception("json format is not valid");

            List<MealFilterValue> lstIngredients = new List<MealFilterValue>();

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
                    MealFilterValue mealFilterValue = new MealFilterValue();

                    if (!apiMealProperties.ContainsKey("strIngredient"))
                        throw new Exception("json is not in the expected format.");

                    mealFilterValue.Name = apiMealProperties["strIngredient"];

                    if (apiMealProperties.ContainsKey("idIngredient"))
                        mealFilterValue.Id = apiMealProperties["idIngredient"];
                    if (apiMealProperties.ContainsKey("strDescription"))
                        mealFilterValue.Description = apiMealProperties["strDescription"];

                    lstIngredients.Add(mealFilterValue);
                    apiMealProperties.Clear();
                    apiMealProperties = null;
                }
            }

            return lstIngredients;
        }

        public override void WriteJson(JsonWriter writer, List<MealFilterValue>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
