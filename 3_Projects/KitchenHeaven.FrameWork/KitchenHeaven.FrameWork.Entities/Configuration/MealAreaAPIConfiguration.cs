namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    /// <summary>
    /// Class representing configuration to use API methods based on meal's area
    /// </summary>
    public class MealAreaAPIConfiguration
    {
        public MealAreaAPIConfiguration()
        { 
        }

        /// <summary>
        /// Name of API method to filter meal by area
        /// </summary>
        public string APIFilterMethod { get; set; }

        /// <summary>
        /// Name of API method to list all Are
        /// </summary>
        public string APIListMethod { get; set; }

        /// <summary>
        /// Name of the parameter used to call API
        /// </summary>
        public string APIArgument { get; set; }
    }
}
