namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    public class APIConfiguration
    {
        public string APIUrl { get; set; }
        public string APIKey { get; set; }
        MealAreaAPIConfiguration MealAreaAPIConfiguration { get; } = new MealAreaAPIConfiguration();
        MealCategoryAPIConfiguration MealCategoryAPIConfiguration { get; } = new MealCategoryAPIConfiguration();
        MealIngredientAPIConfiguration MealIngredientAPIConfiguration { get; } = new MealIngredientAPIConfiguration();
        MealNameAPIAccessConfiguration MealNameAPIConfiguration { get; } = new MealNameAPIAccessConfiguration();

    }
}
