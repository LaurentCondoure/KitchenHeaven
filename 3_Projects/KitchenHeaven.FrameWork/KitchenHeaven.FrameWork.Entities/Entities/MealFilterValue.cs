using KitchenHeaven.FrameWork.DataObject.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataObject.Entities
{
    /// <summary>
    /// Class representing a filter value
    /// </summary>
    public class MealFilterValue
    {
        /// <summary>
        /// Type of the filter : meal/category/area/ingredient
        /// </summary>
        public FilterType FilterType { get; set; }
        /// <summary>
        /// Id of the filter
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name of the filter
        /// /!\ Used as parameters for TheMealDb API to filter meal by name, ingredient, cotegory or area
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Description of the filter
        /// </summary>
        public string Description { get; set; }
    }
}
