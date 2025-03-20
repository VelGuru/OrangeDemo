using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeDemo.Config
{
    public class ConfigReader
    {
        public static string getUrl(string environment)
        {
            switch(environment.ToLower())
            {
                case "qa":
                    return ConfigurationManager.AppSettings["qa"];
                case "uat":
                    return ConfigurationManager.AppSettings["uat"];
                case "prod":
                    return ConfigurationManager.AppSettings["prod"];
            }
            return null;
        }
    }
}
