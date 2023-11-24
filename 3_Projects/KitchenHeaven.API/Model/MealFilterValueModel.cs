using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;

namespace KitchenHeaven.API.Model
{
    public class MealFilterValueModel
    {
        //TODO : uncomment with package nuget
        public FilterType FilterType { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public MealFilterValue GetObjectFromModel()
        {
            return new MealFilterValue()
            {
                FilterType = FilterType,
                Id = Id,
                Name = Name,
                Description = Description
            };
        }

        public static MealFilterValueModel GetModelFromObject(MealFilterValue mealFilterValue)
        {
            return new MealFilterValueModel() {
                FilterType = mealFilterValue.FilterType,
                Id = mealFilterValue.Id,
                Name = mealFilterValue.Name,
                Description = mealFilterValue.Description
            };
        }
    }
}
