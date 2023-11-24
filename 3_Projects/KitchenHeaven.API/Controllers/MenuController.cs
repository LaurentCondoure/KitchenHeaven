using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

using KitchenHeaven.API.Model;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.Service.Interfaces;

namespace KitchenHeaven.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private IMenuService _menuService;

        public MenuController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet(Name="GetRestaurantMenu")]
        public IActionResult GetRestaurantMenu([FromRoute]int restaurantId)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                IEnumerable<Meal> menu = _menuService.GetMenu(restaurantId);
                if (menu == null)
                {
                    return StatusCode(500, "list of Resturant should not be null without exception");
                }
                List<MealModel> menuModel = new List<MealModel>();
                menu.ToList().ForEach(meal => menuModel.Add(MealModel.GetModelFromObject(meal)));

                return new JsonResult(menuModel);

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


        [HttpPost(Name = "EditMeal")]
        public IActionResult EditMenu([FromBody] int restaurantId, [FromBody]List<string> mealExternalIds)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                Dictionary<string, string> addResult = new Dictionary<string, string>();
                IEnumerable<Meal> menu = _menuService.AddMeal(restaurantId, mealExternalIds, out addResult);
                if (menu == null)
                {
                    return StatusCode(500, "list of Resturant should not be null without exception");
                }
                List<MealModel> menuModel = new List<MealModel>();
                menu.ToList().ForEach(meal => menuModel.Add(MealModel.GetModelFromObject(meal)));

                return new JsonResult(menuModel);

            }
            catch (SqliteException sqlException)
            {
                return StatusCode(500, "SQL ERROR =>" + sqlException.ToString());
            }
            catch (HttpRequestException sqlException)
            {
                return StatusCode(500, "RequestAPI ERROR =>" + sqlException.ToString());
            }
            catch (Exception exc)
            {
                return StatusCode(500, "Server ERROR =>" + exc.ToString());
            }
        }
    }
}
