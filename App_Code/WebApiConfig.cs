using System.Web.Http;
using JsonMapping.Filters;
using JsonMapping.Serialisation;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonMapping
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new ValidateModelAttribute());

            var contractResolver = HtmlSanitisingContractResolver.Instance;
            contractResolver.NamingStrategy = new PiecewiseNamingStrategy(new CamelCaseNamingStrategy())
            {
                OverrideSpecifiedNames = true,
                ProcessDictionaryKeys = true
            };

            var serializerSettings = config.Formatters.JsonFormatter.SerializerSettings;
            serializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
            serializerSettings.ContractResolver = contractResolver;
            serializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
            serializerSettings.Converters.Add(new SportConverter());
        }
    }
}