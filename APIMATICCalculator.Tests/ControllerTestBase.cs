using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using APIMATICCalculator.UWP;
using APIMATICCalculator.Tests.Helpers;
 
using APIMATICCalculator.UWP.Models;

namespace APIMATICCalculator.Tests
{
    [TestClass]
    public class ControllerTestBase
    {
        //Test setup
        public const int REQUEST_TIMEOUT = 60;
        protected const double ASSERT_PRECISION = 0.1;
        public TimeSpan globalTimeout = TimeSpan.FromSeconds(REQUEST_TIMEOUT);

        protected HttpCallBackEventsHandler httpCallBackHandler = new HttpCallBackEventsHandler();

        [TestInitialize]
        public void SetUp()
        {
            //hooking events for catching http requests and responses
            GetClient().SharedHttpClient.OnBeforeHttpRequestEvent += httpCallBackHandler.OnBeforeHttpRequestEventHandler;
            GetClient().SharedHttpClient.OnAfterHttpResponseEvent += httpCallBackHandler.OnAfterHttpResponseEventHandler;
        }

        // Singleton instance of client for all test classes
        private static APIMATICCalculatorClient client;
        private static object clientSync = new object();

        /// <summary>
        /// Get client instance
        /// </summary>
        /// <returns></returns>
        public static APIMATICCalculatorClient GetClient()
        {
            lock (clientSync)
            {
                if (client == null)
                {
                    client = new APIMATICCalculatorClient();
                }
                return client;
            }
        }

        /// <summary>
        /// Apply test configuration
        /// </summary>
        protected static void applyConfiguration()
        {
            // Set Configuration parameters for test execution
            Configuration.Environment = Configuration.Environments.PRODUCTION;
        }
    }
}