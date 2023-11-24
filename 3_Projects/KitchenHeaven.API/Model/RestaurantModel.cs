using KitchenHeaven.FrameWork.DataObject.Entities;
using System.ComponentModel.DataAnnotations;

namespace KitchenHeaven.API.Model
{
    public class RestaurantModel
    {
        public int id { get; set; }
        //[Required]
        [StringLength(30)]
        public string Name { get; set; }

        //[Required]
        [StringLength(20)]
        public string BusinessIdentifier { get; set; }

        [StringLength(76)]
        public string Address { get; set; }

        [StringLength(76)]
        public string AddressComplement { get; set; }

        [StringLength(10)]
        public string CityCode { get; set; }

        [StringLength(50)]
        public string CityName { get; set; }

        [StringLength(10)]
        public string Manager { get; set; }

        public Restaurant GetObjectFromModel()
        {
            return new Restaurant()
            {
                id = id,
                Name = Name,
                BusinessIdentifier = BusinessIdentifier,
                Address = Address,
                AddressComplement = AddressComplement,
                CityCode = CityCode,
                CityName = CityName,
                Manager = Manager
            };
        }

        public static RestaurantModel GetModelFromObject(Restaurant restaurant)
        {
            return new RestaurantModel()
            {
                id = restaurant.id,
                Name = restaurant.Name,
                BusinessIdentifier = restaurant.BusinessIdentifier,
                Address = restaurant.Address,
                AddressComplement = restaurant.AddressComplement,
                CityCode = restaurant.CityCode,
                CityName = restaurant.CityName,
                Manager = restaurant.Manager
            };
        }
    }
}
