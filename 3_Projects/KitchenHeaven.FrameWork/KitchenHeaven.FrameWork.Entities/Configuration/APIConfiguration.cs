namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    public class APIConfiguration : IAPIConfiguration
    {
        public APIConfiguration()
        { }

        public GeneralAPIConfiguration  General { get; set; } 
        public MealAreaAPIConfiguration MealArea { get; set; } 
        public MealCategoryAPIConfiguration MealCategory { get; set; } 
        public MealIngredientAPIConfiguration MealIngredient { get; set; } 
        public MealAPIAccessConfiguration Meal { get; set; } 

    }
}
