using KitchenHeaven.FrameWork.DataObject.Entities;

namespace KitchenHeaven.API.Model
{
    public class MealModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string ExternalId { get; set; }

        public string Category { get; set; }

        public string Area { get; set; }

        public string Image { get; set; }

        public string Miniature { get; set; }

        public string Instructions { get; set; }

        public List<IngredientModel> Ingredients { get; set; }

        public Meal GetObjectFromModel()
        {
            return new Meal() { 
                Id = Id,
                Name = Name,
                ExternalId = ExternalId,
                Category = Category,
                Area = Area,
                Image = Image,
                Miniature = Miniature,
                Instructions = Instructions
            };
        }

        public static MealModel GetModelFromObject(Meal meal)
        {
            return new MealModel() { 
                Area = meal.Area,
                Image = meal.Image,
                Miniature = meal.Miniature,
                Instructions = meal.Instructions,
                Category = meal.Category,
                ExternalId=meal.ExternalId,
                Id = meal.Id,
                Name = meal.Name,
            };
        }

    }
}
