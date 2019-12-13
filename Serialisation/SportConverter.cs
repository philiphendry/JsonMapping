using System;
using JsonMapping.Models;
using Newtonsoft.Json.Linq;

namespace JsonMapping.Serialisation
{
    public class SportConverter : JsonCreationConverter<ISport>
    {
        protected override ISport Create(Type objectType, JObject jObject)
        {
            var sportName = (string)jObject.Property("name");
            switch (sportName.ToLower())
            {
                case "squash":
                    return new Squash();
                case "football":
                    return new Football();
                default:
                    throw new InvalidOperationException($"The sport name '{sportName}' cannot be found.");
            }
        }
    }
}