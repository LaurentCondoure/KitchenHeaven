using KitchenHeaven.FrameWork.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.Entities
{
    public class MealFilterValue
    {
        public FilterType FilterType { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
