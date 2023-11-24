using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    /// <summary>
    /// Class representing all MealDb configuration needed to reqsuest the mealDb
    /// </summary>
    public interface IAPIConfiguration
    {
        public GeneralAPIConfiguration General { get; set; }
        public MealAreaAPIConfiguration MealArea { get; set; }
        public MealCategoryAPIConfiguration MealCategory { get; set; }
        public MealIngredientAPIConfiguration MealIngredient { get; set; }
        public MealAPIAccessConfiguration Meal { get; set; }
    }
}
