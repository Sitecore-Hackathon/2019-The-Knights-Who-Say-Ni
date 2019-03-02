using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sitecore.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Knights.Feature.KeywordFieldHelper.Processors
{
    public class RegisterApiRoutes
    {
        public void Process(PipelineArgs args)
        {
            HttpConfiguration config = GlobalConfiguration.Configuration;

            SetRoutes(config);
            SetSerializerSettings(config);
        }

        private void SetRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("Keywords", "keywordfieldhelper/keywords", new { action = "Get", controller = "Keywords" });
            config.Routes.MapHttpRoute("Default route", "keywordfieldhelper/{controller}", new { action = "Get" });
        }

        private void SetSerializerSettings(HttpConfiguration config)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings { ContractResolver = new DefaultContractResolver() };
            config.Formatters.JsonFormatter.SerializerSettings = settings;
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            config.EnsureInitialized();
        }
    }
}