using System;
using System.Collections.Generic;


using Newtonsoft.Json;
using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.FrameWork.DataObject.ApiJsonConvert
{
    /// <summary>
    /// Convert TheMealDb json format in KitchenHeaven MealFilterValue generic object 
    /// </summary>
    public class CategoryJsonConverter : JsonConverter<List<MealFilterValue>>
    {
        public override List<MealFilterValue>? ReadJson(JsonReader reader, Type objectType, List<MealFilterValue>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;
            if (reader.TokenType != JsonToken.StartArray)
                throw new Exception("json format is not valid");

            List<MealFilterValue> lstMealFilter = new List<MealFilterValue>();
            while (reader.Read())
            {
                if (reader.TokenType == JsonToken.String)
                {
                    MealFilterValue mealFilterValue = new MealFilterValue()
                    {
                        Name = reader.Value.ToString(),
                    };
                    lstMealFilter.Add(mealFilterValue);
                }
            }

            return lstMealFilter;
        }

        public override void WriteJson(JsonWriter writer, List<MealFilterValue>? value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
