using System.Collections.Generic;
using System.Text;
using APIMATICCalculator.UWP.Models;
using APIMATIC.SDK.Common;

namespace APIMATICCalculator.UWP
{
    public partial class Configuration
    {
        public enum Environments
        {
            PRODUCTION,
        }
        public enum Servers
        {
            DEFAULT,
        }

        //The current environment being used
        public static Environments Environment = Environments.PRODUCTION;

        //The base Uri for API calls
        public static string BaseUri = "http://examples-apimatic-io-{0}.runscope.net/apps/calculator";

        //get your bucket id from runscope.com
        //TODO: Replace the RunscopeBucketKey with an appropriate value
        public static string RunscopeBucketKey = "TODO: Replace";

        //The OAuth 2.0 access token to be set before API calls
        //TODO: Replace the OAuthAccessToken with an appropriate value
        public static string OAuthAccessToken = "TODO: Replace";

        //A map of environments and their corresponding servers/baseurls
        public static Dictionary<Environments, Dictionary<Servers, string>> EnvironmentsMap =
            new Dictionary<Environments, Dictionary<Servers, string>>
            {
                { 
                    Environments.PRODUCTION,new Dictionary<Servers, string>
                    {
                        { Servers.DEFAULT,"http://examples-apimatic-io-{runscope-bucket-key}.runscope.net/apps/calculator" },
                    }
                },
            };

        /// <summary>
        /// Makes a list of the BaseURL parameters 
        /// </summary>
        /// <return>Returns the parameters list</return>
        internal static List<KeyValuePair<string, object>> GetBaseURIParameters()
        {
            List<KeyValuePair<string, object>> kvpList = new List<KeyValuePair<string, object>>()
            {
            };
            return kvpList; 
        }

        /// <summary>
        /// Gets the URL for a particular alias in the current environment and appends it with template parameters
        /// </summary>
        /// <param name="alias">Default value:DEFAULT</param>
        /// <return>Returns the baseurl</return>
        internal static string GetBaseURI(Servers alias = Servers.DEFAULT)
        {
            StringBuilder Url =  new StringBuilder(EnvironmentsMap[Environment][alias]);
            APIHelper.AppendUrlWithTemplateParameters(Url, GetBaseURIParameters());
            return Url.ToString();        
        }
    }
}