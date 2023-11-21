using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.Entities
{
    public class MealIngredient
    {
        public int MealId { get; set; }
        public int IngredientId { get; set; }
        public string Measure { get; set; }
    }

}
