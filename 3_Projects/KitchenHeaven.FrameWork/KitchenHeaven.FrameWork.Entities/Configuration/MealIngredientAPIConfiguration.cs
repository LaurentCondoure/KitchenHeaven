namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    /// <summary>
    /// Class representing configuration to use API methods based on meal's category
    /// </summary>
    public class MealIngredientAPIConfiguration
    {
        public MealIngredientAPIConfiguration()
        {}
        /// <summary>
        /// Name of API method to filter meal 
        /// </summary>
        public string APIFilterMethod { get; set; }

        /// <summary>
        /// Name of API method to list all Category
        /// </summary>
        public string APIListMethod { get; set; }

        /// <summary>
        /// Name of the parameter used to call API
        /// </summary>
        public string APIArgument { get; set; }
    }
}
