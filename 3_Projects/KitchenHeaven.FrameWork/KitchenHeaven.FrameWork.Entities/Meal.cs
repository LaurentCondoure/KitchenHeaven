using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.Entities
{
    public class Meal
    {
        public string Name { get; set; }

        public string ExternalId { get; set; }

        public string Category { get; set; }

        public string Area { get; set; }

        public string Image { get; set; }

        public string Miniature { get; set; }

        public string Instructions { get; set; }

        public List<Ingredient> Ingredients { get; set; }



    }
}
