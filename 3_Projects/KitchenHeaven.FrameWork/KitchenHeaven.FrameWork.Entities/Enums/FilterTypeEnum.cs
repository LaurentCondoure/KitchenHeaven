using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataObject.Enums
{
    [Flags]
    public enum FilterType
    {
        Meal = 1,
        Area = 2,
        Category = 4,
        Ingredient = 8
    }
}
