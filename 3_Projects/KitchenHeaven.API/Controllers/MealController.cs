using KitchenHeaven.API.Model;
using KitchenHeaven.FrameWork.DataObject.Entities;
using KitchenHeaven.FrameWork.DataObject.Enums;
using KitchenHeaven.FrameWork.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace KitchenHeaven.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IMealService _mealService;

        public MealController(IMealService mealService)
        {
            _mealService = mealService;
        }



        [HttpGet]
        public IActionResult GetFiltersByType([FromBody] FilterType filterType)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {

                IEnumerable<MealFilterValue> filters = _mealService.GetFilters(filterType);
                List<MealFilterValueModel> lstfilterModel = new List<MealFilterValueModel>();
                filters.ToList().ForEach(filter => lstfilterModel.Add(MealFilterValueModel.GetModelFromObject(filter)));
                return Ok(lstfilterModel);
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

        [HttpPost]
        public IActionResult SearchMeal([FromBody] MealFilterValueModel mealFilterValueModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                MealFilterValue mealFilterValue = mealFilterValueModel.GetObjectFromModel();
                IEnumerable<Meal> meals = _mealService.Search(mealFilterValue);
                List<MealModel> lstmealModel = new List<MealModel>();
                meals.ToList().ForEach(meal => lstmealModel.Add(MealModel.GetModelFromObject(meal)));
                return Ok(lstmealModel);
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