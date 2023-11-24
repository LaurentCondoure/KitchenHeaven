using System;
using System.Collections.Generic;
using System.Text;

namespace KitchenHeaven.FrameWork.DataObject.Configuration
{
    /// <summary>
    /// class representing General Parameters of TheMealDb API
    /// </summary>
    public class GeneralAPIConfiguration
    {
        public GeneralAPIConfiguration()
        { }

        /// <summary>
        /// Main Url of the API
        /// </summary>
        public string APIUrl { get; set; }

        /// <summary>
        /// API Key
        /// </summary>
        public string APIKey { get; set; }
    }
}
