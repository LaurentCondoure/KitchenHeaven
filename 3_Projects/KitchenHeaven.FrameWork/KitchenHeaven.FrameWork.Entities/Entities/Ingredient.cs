using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataObject.Entities
{
    public class Ingredient
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }
    }
}
