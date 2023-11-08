using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMealDb_API
{
    internal class Parameters
    {
        public string TheMealDbUrl { get; set; }
        public string TheMealDbApiKey { get; set; }
        public Parameters()
        { 
        }

        public void Init()
        {
            if (ConfigurationManager.AppSettings.GetValues("TheMealDb_URL") != null)
            {
                TheMealDbUrl = ConfigurationManager.AppSettings["TheMealDb_URL"];
            }

            if (ConfigurationManager.AppSettings.GetValues("TheMealDb_APIKey") != null)
            {
                TheMealDbApiKey = ConfigurationManager.AppSettings["TheMealDb_APIKey"];
            }
        }
    }
}
