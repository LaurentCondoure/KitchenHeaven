using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealDb_API
{
    /// <summary>
    /// Class provides methods to request the mealDb api and save samples api request
    /// </summary>
    internal class TheMealDb_Service
    {

        private readonly Parameters _parameters;

        public TheMealDb_Service(Parameters parameters)
        {
            _parameters = parameters;
        }

        /// <summary>
        /// Calls the search Api by meal's name and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="name">name of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool SearchMealByName(string name)
        {

            try
            {
                string searchByNameApi = Path.Combine(_parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"search.php?s={name}");
                string returnedMeals = RequestMealDbAPI(searchByNameApi);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"SearchMealByName_{name}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the search Api by meal's name first letter and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="letter">first letter of th name of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool ListMealsByFirstLetter(string letter)
        {
            if (string.IsNullOrEmpty(letter))
                return false;

            try
            {
                string listByFirstLetterAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"search.php?f={letter}");
                string returnedMeals = RequestMealDbAPI(listByFirstLetterAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"ListMealsByFirstLetter_{letter}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get details by id API and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="id">id of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetMealsDetailById(string id)
        {

            if (string.IsNullOrEmpty(id))
                return false;

            try
            {
                string GetMealsDetailByIdAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"lookup.php?i={id}");
                string returnedMeals = RequestMealDbAPI(GetMealsDetailByIdAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetMealsDetailByIdAPI _{id}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get random meal API and save the result as a json file in the Export directory
        /// </summary>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetRandomMeal()
        {
            try
            {
                string GetRandomMealAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"random.php");
                string returnedMeals = RequestMealDbAPI(GetRandomMealAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetRandomMeal.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get random meal API and save the result as a json file in the Export directory
        /// </summary>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool ListAllMealsCategories()
        {
            try
            {
                string ListAllMealsCategoriesAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"categories.php");
                string returnedMeals = RequestMealDbAPI(ListAllMealsCategoriesAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"ListAllMealsCategories.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get list of categories API and save the result as a json file in the Export directory
        /// </summary>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetCategoriesList()
        {
            try
            {
                string GetCategoriesListAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"list.php?c=list");
                string returnedMeals = RequestMealDbAPI(GetCategoriesListAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetCategoriesList.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get list of areas API and save the result as a json file in the Export directory
        /// </summary>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetAreasList()
        {
            try
            {
                string GetAreasListAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"list.php?a=list");
                string returnedMeals = RequestMealDbAPI(GetAreasListAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetAreasList.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the get list of ingredients API and save the result as a json file in the Export directory
        /// </summary>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetIngredientsList()
        {
            try
            {
                string GetIngredientsListAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"list.php?i=list");
                string returnedMeals = RequestMealDbAPI(GetIngredientsListAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetIngredientsList.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the filter meals by main ingredient API and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="ingredient">id of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetMealsListByIngredient(string ingredient)
        {
            try
            {
                string GetMealsListByIngredientAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"filter.php?i={ingredient}");
                string returnedMeals = RequestMealDbAPI(GetMealsListByIngredientAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetMealsListByIngredient_{ingredient}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the filter meals by main ingredient API and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="ingredient">id of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetMealsListByCategory(string category)
        {
            try
            {
                string GetMealsListByCategoryAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"filter.php?c={category}");
                string returnedMeals = RequestMealDbAPI(GetMealsListByCategoryAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetMealsListByCategory_{category}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// Calls the filter meals by main ingredient API and save the result as a json file in the Export directory
        /// </summary>
        /// <param name="ingredient">id of the meal to retrieve</param>
        /// <returns>Boolean indicates if the call is successfull and sample json saved</returns>
        public bool GetMealsListByArea(string area)
        {
            try
            {
                string GetMealsListByAreaAPI = String.Join(@"\", _parameters.TheMealDbUrl, _parameters.TheMealDbApiKey, $"filter.php?a={area}");
                string returnedMeals = RequestMealDbAPI(GetMealsListByAreaAPI);
                using (StreamWriter sw = new StreamWriter(Path.Combine(Environment.CurrentDirectory, "Export", $"GetMealsListByArea_{area}.json")))
                {
                    sw.Write(returnedMeals);
                    sw.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        #region Private Methods
        private string RequestMealDbAPI(string url)
        {
            using (HttpClient apiRequest = new HttpClient())
            {

                Task<string> apiReturn = apiRequest.GetStringAsync(url);
                apiReturn.Wait();
                return apiReturn.Result;
            }
        }

        #endregion
    }
}
