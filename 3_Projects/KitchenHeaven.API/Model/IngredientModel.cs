using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.API.Model
{
    public class IngredientModel
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string ExternalId { get; set; }
        public string Description { get; set; }
        public string Measure { get; set; }

        public Ingredient GetObjectFromModel()
        {
            return new Ingredient() { 
                id = id,
                Name = Name,
                ExternalId = ExternalId,
                Description = Description,
                Measure = Measure
            };
        }

        public static IngredientModel GetModelFromObject(Ingredient ingredient)
        {
            return new IngredientModel()
            {
                id = ingredient.id,
                Name = ingredient.Name,
                ExternalId = ingredient.ExternalId,
                Description = ingredient.Description,
                Measure = ingredient.Measure
            };
        }
    }
}
