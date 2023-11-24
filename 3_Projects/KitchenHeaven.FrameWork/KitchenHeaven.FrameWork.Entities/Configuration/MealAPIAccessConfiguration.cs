namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    /// <summary>
    /// Class representing configuration to use API methods based on meal's name or id
    /// </summary>
    public class MealAPIAccessConfiguration
    {
        public MealAPIAccessConfiguration()
        { }

        /// <summary>
        /// Name of API method to filter meal by name
        /// </summary>
        public string APINameFilterMethod { get; set; }

        /// <summary>
        /// Name of API method to filter meal by id
        /// </summary>
        public string APIIdFilterMethod { get; set; }

        /// <summary>
        /// Name of Argument to filter meal by firstletter of name
        /// </summary>
        public string APIFirstLetterArgument { get; set; }

        /// <summary>
        /// Name of Argument to filter meal by name
        /// </summary>
        public string APINameArgument { get; set; }

        /// <summary>
        /// Name of Argument to filter meal by id
        /// </summary>
        public string APIIdArgument { get; set; }
    }

}
