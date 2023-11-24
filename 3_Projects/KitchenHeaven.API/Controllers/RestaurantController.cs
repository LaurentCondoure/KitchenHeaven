using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Microsoft.Data.Sqlite;

using KitchenHeaven.API.Model;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.Service.Interfaces;


namespace KitchenHeaven.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                Restaurant restaurant = _restaurantService.GetById(id);
                RestaurantModel model = RestaurantModel.GetModelFromObject(restaurant);

                return new JsonResult(model);

            }
            catch (SqliteException sqlException)
            {
                return StatusCode(500, "SQL ERROR =>" + sqlException.ToString());
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Server ERROR =>" + exc.ToString());
            }

            
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Add([FromBody] RestaurantModel restaurantModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                return StatusCode(404);

            }
            catch (SqliteException sqlException)
            {
                return StatusCode(500, "SQL ERROR =>" + sqlException.ToString());
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Server ERROR =>" + exc.ToString());
            }

        }

        // POST api/<RestaurantController>
        [HttpPost]
        public void Search([FromBody] RestaurantModel restaurantModel)
        {
        }

        [HttpPost]
        public IActionResult GetAll()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                IEnumerable<Restaurant> lstRestaurant = _restaurantService.GetAll();
                if (lstRestaurant == null)
                {
                    return StatusCode(500, "list of Resturant should not be null without exception");
                }
                List<RestaurantModel> listRestaurantModel = new List<RestaurantModel>();
                lstRestaurant.ToList().ForEach(restaurant => listRestaurantModel.Add(RestaurantModel.GetModelFromObject(restaurant)));

                return new JsonResult(listRestaurantModel);
            }
            catch (SqliteException sqlException)
            {
                return StatusCode(500, "SQL ERROR =>" + sqlException.ToString());
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Server ERROR =>" + exc.ToString());
            }
        }
    }
}
