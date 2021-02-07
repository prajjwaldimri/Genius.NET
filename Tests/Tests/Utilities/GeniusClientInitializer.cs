using Genius;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace Tests.Utilities
{
    public static class GeniusClientInitializer
    {
        public static GeniusClient GetClient()
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration("Tests.dll");
            string apiKey = configuration.AppSettings.Settings["API_KEY"]?.Value;
            return new GeniusClient(apiKey);
        }
    }
}
