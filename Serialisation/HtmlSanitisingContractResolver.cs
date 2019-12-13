using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace JsonMapping.Serialisation
{
    /// <summary>
    /// Note how this implements CamelCasePropertyNamesContractResolver - it's not the most elegant
    /// way to combine the resolvers but NewtonSoft doesn't provide a better option.
    ///
    /// The HtmlSanitisingContractResolver automatically finds properties on deserializing models
    /// that are decorated with AllowHtml or AllowHtmlAttribute. It then assures that any data
    /// set on the property is sanitised such that any HTML not on a white-list is removed.
    /// 
    /// </summary>
    public class HtmlSanitisingContractResolver : DefaultContractResolver
    {
        protected HtmlSanitisingContractResolver()
        { }

        // As of 7.0.1, Json.NET suggests using a static instance for "stateless" contract resolvers, for performance reasons.
        // http://www.newtonsoft.com/json/help/html/ContractResolver.htm
        // http://www.newtonsoft.com/json/help/html/M_Newtonsoft_Json_Serialization_DefaultContractResolver__ctor_1.htm
        // "Use the parameterless constructor and cache instances of the contract resolver within your application for optimal performance."

        // Using an explicit static constructor enables lazy initialization.
        static HtmlSanitisingContractResolver()
        {
            Instance = new HtmlSanitisingContractResolver();
        }

        public static HtmlSanitisingContractResolver Instance { get; }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            var properties = base.CreateProperties(type, memberSerialization);
            foreach (var property in properties.Where(p =>
                p.AttributeProvider.GetAttributes(typeof(AllowHtmlAttribute), false).Any()))
            {
                var propertyInfo = type.GetProperty(property.UnderlyingName);
                if (propertyInfo != null)
                {
                    property.ValueProvider = new HtmlSanitisingValueProvider(propertyInfo);
                }
            }
            return properties;
        }


    }

    public class PiecewiseNamingStrategy : NamingStrategy
    {
        readonly NamingStrategy baseStrategy;

        public PiecewiseNamingStrategy(NamingStrategy baseStrategy)
        {
            if (baseStrategy == null)
                throw new ArgumentNullException();
            this.baseStrategy = baseStrategy;
        }

        protected override string ResolvePropertyName(string name)
        {
            var resolvePropertyName = String.Join(".", name.Split('.').Select(n => baseStrategy.GetPropertyName(n, false)));
            Debug.WriteLine($"{name} becomes {resolvePropertyName}");
            return resolvePropertyName;
        }
    }
}