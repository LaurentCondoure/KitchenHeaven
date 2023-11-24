using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KitchenHeaven.FrameWork.DataAccess.DataAccess
{
    /// <summary>
    /// Base class to centralize all TheMealDb API request for all APIAccess classes
    /// </summary>
    public class BaseAPIAccess
    {
        protected string RequestMealDbAPI(string url)
        {
            using (HttpClient apiRequest = new HttpClient())
            {

                Task<string> apiReturn = apiRequest.GetStringAsync(url);
                apiReturn.Wait();
                return apiReturn.Result;
            }
        }
    }
}
