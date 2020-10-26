using Newtonsoft.Json.Serialization;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace ACME.WebApi
{
    public class WebApiConfig
    {
        private static bool _isInitialized;
        private static readonly object _locker = new object();
        private static WebApiConfig _instance;
        private readonly HttpConfiguration _configuration;

        protected WebApiConfig(IDependencyResolver dependencyResolver)
        {
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
            var configuration = new HttpConfiguration();
            SetApiCamelCase(configuration);

            configuration.DependencyResolver = dependencyResolver;
            
            _configuration = configuration;
        }

        private static void SetApiCamelCase(HttpConfiguration configuration)
        {
            var jsonFormatter = configuration.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        public static WebApiConfig Instance
        {
            get
            {
                if (_instance == null) throw new Exception("Call Initialize before using Intance.");
                return _instance;
            }
        }

        #region Initialize

        public static WebApiConfig Initialize(IDependencyResolver dependencyResolver)
        {
            if (_isInitialized) return _instance;
            lock (_locker)
            {
                if (!_isInitialized)
                {
                    _instance = new WebApiConfig(dependencyResolver);
                    _isInitialized = true;
                }
            }
            return _instance;
        }

        #endregion
    }
}
